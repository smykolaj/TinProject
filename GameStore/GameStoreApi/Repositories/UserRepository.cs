using GameStore.Models;
using GameStore.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await  _context.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.Users.FirstAsync(u => u.Id.Equals(id));
    }


    public Task<User> EditUser(User userToEdit)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ExistsByEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email));
    }

    public async Task AddUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(string modelEmail)
    {
        return await _context.Users.FirstAsync(u => u.Email.Equals(modelEmail));
    }

    public async Task SetRefreshTokenForUser(User appUser, string reftoken, DateTime addDays)
    {
        appUser.RefreshToken = reftoken;
        appUser.RefreshTokenExp = DateTime.Now.AddDays(1);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByRefToken(string refreshToken)
    {
        return await _context.Users.FirstAsync(u => u.RefreshToken.Equals(refreshToken));
    }

    public Task<bool> ExistsById(int idUser)
    {
        return _context.Users.AnyAsync(u => u.Id.Equals(idUser));
    }

    public Task<List<Purchase>> GetPurchasesOfUser(int idUser)
    {
        throw new NotImplementedException();
    }
}