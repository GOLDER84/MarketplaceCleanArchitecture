namespace Marketplace.Application.Interfaces;
using Marketplace.Domain;
public interface IItemRepository
{
    Task<Item?> GetItemByIdAsync(int id);
    Task<IEnumerable<Item>> GetAllItemAsync();
    Task AddItemAsync(Item item);
    Task RemoveItemAsync(Item item);
    Task BuyItemAsync(Item item);
    Task SaveChangesAsync();
}