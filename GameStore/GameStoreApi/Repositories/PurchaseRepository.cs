using GameStore.Models;
using GameStore.Repositories.Interfaces;

namespace GameStore.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    public Task<List<Purchase>> GetAllPurchases()
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> GetPurchaseById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> CreatePurchase(Purchase purchaseToRegister)
    {
        throw new NotImplementedException();
    }

    public Task<Purchase> EditPurchase(Purchase purchaseToEdit)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeletePurchase(int id)
    {
        throw new NotImplementedException();
    }
}