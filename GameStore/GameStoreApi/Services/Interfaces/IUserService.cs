using GameStore.DTOs;

namespace GameStore.Services.Interfaces;

public interface IUserService
{
    Task<List<GetUserPartialDTO>> GetAllUsers();
    Task<string> GetEmailById(int idUser);
    Task<bool> ExistsById(int idUser);
    Task<GetUserFullDTO> GetFullUserInfo(int idUser);
}