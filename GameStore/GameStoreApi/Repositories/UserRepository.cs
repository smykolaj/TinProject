using GameStore.Models;
using GameStore.Repositories.Interfaces;

namespace GameStore.Repositories;

public class UserRepository : IUserRepository
{
    public Task<List<User>> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetUserById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> RegisterUser(User userToRegister)
    {
        throw new NotImplementedException();
    }

    public Task<User> EditUser(User userToEdit)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsByEmail(string email)
    {
        throw new NotImplementedException();
    }
}