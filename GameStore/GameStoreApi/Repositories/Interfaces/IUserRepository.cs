using GameStore.Models;

namespace GameStore.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User> EditUser(User userToEdit);
    Task<bool> DeleteUser(int id);
    Task<bool> ExistsByEmail(string email);


    Task AddUser(User user);
    Task<User> GetByEmail(string modelEmail);
    Task SetRefreshTokenForUser(User appUser, string reftoken, DateTime addDays);
    Task<User> GetUserByRefToken(string refreshToken);
    Task<bool> ExistsById(int idUser);
    Task<List<Purchase>> GetPurchasesOfUser(int idUser);
}