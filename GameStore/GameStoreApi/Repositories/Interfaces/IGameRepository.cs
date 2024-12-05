using GameStore.Models;

namespace GameStore.Repositories.Interfaces;

public interface IGameRepository
{
    Task<List<Game>> GetAllGames();
    Task<Game> GetGameById(int id);
    Task<Game> CreateGame(Game gameToRegister);
    Task<Game> EditGame(Game gameToEdit);
    Task<bool> DeleteGame(int id);
}