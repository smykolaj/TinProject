using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameStore.DTOs;
using GameStore.Models;
using GameStore.Repositories.Interfaces;
using GameStore.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace GameStore.Services;

public class LoginService(IUserRepository repository, IConfiguration config, Validator validator)
    : ILoginService
{
    public async Task<List<string>> RegisterUser(CreateEditUserDTO dto)
    {
        var errors = await validator.ValidateUser(dto);
        if (errors.Count > 0)
        {
            return errors;
        }

        var hashedPasswordAndSalt = JWTService.GetHashedPasswordAndSalt(dto.Password);
        var user = new User()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            BirthDate = dto.BirthDate,
            Gender = dto.Gender,
            Role = "User",
            Password = hashedPasswordAndSalt.Item1,
            Salt = hashedPasswordAndSalt.Item2,
        };
        await repository.AddUser(user);
        return errors;
    }

    public async Task<LoginResponseModel> Login(LoginRequestModel model)
    {
        if (!await repository.ExistsByEmail(model.Email))
        {
            throw new UnauthorizedAccessException("No such user exists");
        }

        User appUser = await repository.GetByEmail(model.Email);

        var dbpass = appUser.Password;
        var dbsalt = appUser.Salt;
        var userpass = model.Password;
        var resultpass = JWTService.GetHashedPasswordWithSalt(userpass, dbsalt);
        if (!resultpass.Equals(dbpass))
        {
            throw new UnauthorizedAccessException("Wrong credentials");
        }

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]!));

        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        Claim[] userclaim = new[]
        {
            new Claim(ClaimTypes.Name, appUser.Email),
            new Claim(ClaimTypes.Role, appUser.Role)
        };

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: config["JWT:Issuer"],
            audience: config["JWT:Audience"],
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: creds,
            claims: userclaim
        );

        var stringToken = new JwtSecurityTokenHandler().WriteToken(token);


        var reftoken = JWTService.GenerateRefreshToken();
        await repository.SetRefreshTokenForUser(appUser, reftoken, DateTime.Now.AddDays(1));

        return new LoginResponseModel
        {
            Token = stringToken,
            RefreshToken = reftoken
        };
    }


    public async Task<LoginResponseModel> Refresh(string refreshToken)
    {
        var user = await repository.GetUserByRefToken(refreshToken);
        if (user == null)
        {
            throw new SecurityTokenException("Invalid refresh token");
        }

        if (user.RefreshTokenExp < DateTime.Now)
        {
            throw new SecurityTokenException("Refresh token expired");
        }


        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"] ?? string.Empty));

        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        Claim[] userclaim = new[]
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: config["JWT:Issuer"],
            audience: config["JWT:Audience"],
            expires: DateTime.UtcNow.AddMinutes(15),
            signingCredentials: creds,
            claims: userclaim
        );

        var newRefreshToken = JWTService.GenerateRefreshToken();
        await repository.SetRefreshTokenForUser(user, newRefreshToken, DateTime.Now.AddDays(1));

        return new LoginResponseModel()
        {
            RefreshToken = newRefreshToken,
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
}