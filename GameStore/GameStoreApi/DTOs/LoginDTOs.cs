using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;



public class VerifyPasswordRequestModel
{
    public string Password { get; set; } = null!;
    public string Hash { get; set; } = null!;
}

public class LoginRequestModel
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LoginResponseModel
{
    public string Token { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
}

public class RefreshTokenRequestModel
{
    public string RefreshToken { get; set; } = null!;
}

