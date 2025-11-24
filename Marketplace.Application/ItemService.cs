using Service;
using Service.Interfaces.Repsitoreis;

namespace Marketplace.Application;
using Marketplace.Application.Interfaces;
using Marketplace.Domain;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserSessionService _userSessionService;
    public ItemService(IItemRepository itemRepository, IUserRepository userRepository , IUserSessionService userSessionService)
    {
        _itemRepository = itemRepository;
        _userRepository = userRepository;
        _userSessionService = userSessionService;
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


    public async Task<string> BuyAsync(int itemId)
    {
        var user = _userSessionService.GetCurrentUser();
        if (user == null)
        {
            return "User not logged in. Please login first.";
        }

        var item = await _itemRepository.GetItemByIdAsync(itemId);
        if (item == null)
        {
            return "Item not found";
        }
        
        var dbUser = await _userRepository.GetUserByIdAsync(user.id);
        if (dbUser == null)
        {
            return "User not found in database.";
        }

        if (dbUser.credit < item.price)
        {
            return "Insufficient credit";
        }

        dbUser.credit -= item.price;
        await _userRepository.UpdateUserAsync(dbUser);
        await _itemRepository.RemoveItemAsync(item);
        
        await _userRepository.SaveAsync();
        await _itemRepository.SaveChangesAsync();
        
        _userSessionService.SetCurrentUser(dbUser);

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