
using Marketplace.Domain;

namespace Service;

public interface IItemService
{
    Task<string> AddAsync(string name , double price , string description);
    Task<string> RemoveAsync(int id);
    Task<string> BuyAsync(int itemId);
    Task<IReadOnlyList<Item>> GetAllAsync();
    Task<Item?> GetByIdAsync(int itemId);
}