using GameStore.DTOs;

namespace GameStore.Services.Interfaces;

public interface ILoginService
{
    Task<List<string>> RegisterUser(CreateEditUserDTO dto);
    Task<LoginResponseModel> Login(LoginRequestModel model);
    Task<LoginResponseModel> Refresh(string refreshToken);
}