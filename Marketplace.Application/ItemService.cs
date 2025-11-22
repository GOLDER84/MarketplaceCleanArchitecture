using Service;
using Service.Interfaces.Repsitoreis;

namespace Marketplace.Application;
using Marketplace.Application.Interfaces;
using Marketplace.Domain;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IUserRepository _userRepository;

    public ItemService(IItemRepository itemRepository, IUserRepository userRepository)
    {
        _itemRepository = itemRepository;
        _userRepository = userRepository;
    }
    public async Task<string> AddAsync(string name, double price, string description)
    {
        var item = new Item(name, price, description);
        await _itemRepository.AddItemAsync(item);
        await _itemRepository.SaveChangesAsync();
        return "Item added successfully";
    }

    public async Task<string> RemoveAsync(int id)
    {
        var item = await _itemRepository.GetItemByIdAsync(id);
        if (item != null)
        {
            await _itemRepository.RemoveItemAsync(item);
            await _itemRepository.SaveChangesAsync();
            return "Item removed successfully";
        }
        else
        {
            return "Item not found";
        }
    }

    public async Task<string> BuyAsync(string username, int itemId)
    {
        var user = await _userRepository.GetUserByUserNameAsync(username);
        var item = await _itemRepository.GetItemByIdAsync(itemId);
        if (user == null)
        {
            return "User not found";
        }
        if (item == null)
        {
            return "Item not found";
        }
        if (user.credit < item.price)
        {
            return "Insufficient credit";
        }
        user.credit -= item.price;
        await _itemRepository.BuyItemAsync(item);
        await _itemRepository.SaveChangesAsync();
        return "Item purchased successfully";
    }

    public async Task<IReadOnlyList<Item>> GetAllAsync()
    {
        var items = await _itemRepository.GetAllItemAsync();
        return items.ToList().AsReadOnly();
    }

    public async Task<Item?> GetByIdAsync(int itemId)
    {
        return await _itemRepository.GetItemByIdAsync(itemId);
    }
}