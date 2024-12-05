using GameStore.Models;

namespace GameStore.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsers();
    Task<User> GetUserById(int id);
    Task<User> RegisterUser(User userToRegister);
    Task<User> EditUser(User userToEdit);
    Task<bool> DeleteUser(int id);
    Task<bool> ExistsByEmail(string email);
    

}