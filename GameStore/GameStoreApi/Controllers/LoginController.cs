using GameStore.DTOs;
using GameStore.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

[Controller]
[Route("api/[controller]")]
public class LoginController(ILoginService service) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequestModel model)
    {
        try
        {
            LoginResponseModel credentials = await service.Login(model);
            return Ok(credentials);
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized("unauthorized");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(CreateEditUserDTO model)
    {
        try
        {
            var errors = await service.RegisterUser(model);
            if (errors.Count.Equals(0))
                return await Login(new LoginRequestModel
                {
                    Email = model.Email,
                    Password = model.Password
                });
            return BadRequest(errors);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [Authorize(AuthenticationSchemes = "IgnoreTokenExpirationScheme")]
    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(string refreshToken)
    {
        LoginResponseModel responseModel;
        try
        {
            responseModel = await service.Refresh(refreshToken);
            return Ok(responseModel);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}