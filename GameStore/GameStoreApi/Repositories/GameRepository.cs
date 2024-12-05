using GameStore.Models;
using GameStore.Repositories.Interfaces;

namespace GameStore.Repositories;

public class GameRepository : IGameRepository
{
    public Task<List<Game>> GetAllGames()
    {
        throw new NotImplementedException();
    }

    public Task<Game> GetGameById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Game> CreateGame(Game gameToRegister)
    {
        throw new NotImplementedException();
    }

    public Task<Game> EditGame(Game gameToEdit)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteGame(int id)
    {
        throw new NotImplementedException();
    }
}