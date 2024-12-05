using GameStore.Models;

namespace GameStore.Repositories.Interfaces;

public interface IPurchaseRepository
{
    Task<List<Purchase>> GetAllPurchases();
    Task<Purchase> GetPurchaseById(int id);
    Task<Purchase> CreatePurchase(Purchase purchaseToRegister);
    Task<Purchase> EditPurchase(Purchase purchaseToEdit);
    Task<bool> DeletePurchase(int id);
}