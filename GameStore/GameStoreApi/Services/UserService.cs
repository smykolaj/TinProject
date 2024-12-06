using GameStore.DTOs;
using GameStore.Models;
using GameStore.Repositories.Interfaces;
using GameStore.Services.Interfaces;

namespace GameStore.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetUserPartialDTO>> GetAllUsers()
    {
        var list = (await _repository.GetAllUsers()).Select(user => new GetUserPartialDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                Id = user.Id
            })
            .ToList();
        return list;
    }

    public async Task<string> GetEmailById(int idUser)
    {
        var user = await _repository.GetUserById(idUser);
        return user.Email;
    }

    public async Task<bool> ExistsById(int idUser)
    {
        return await _repository.ExistsById(idUser);
    }

    public async Task<GetUserFullDTO> GetFullUserInfo(int idUser)
    {
        var user = await _repository.GetUserById(idUser);
        var userDto = new GetUserFullDTO()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender,
            Id = user.Id,
            BirthDate = user.BirthDate,
            Role = user.Role,
            Purchases = (await _repository.GetPurchasesOfUser(idUser)).Select(purchase => new GetPurchaseFullDTO()
            {
                Id = purchase.Id,
                GameId = purchase.GameId,
                PurchaseDate = purchase.PurchaseDate,
                UserId = purchase.UserId
            }).ToList()
        };
        return userDto;
    }
}