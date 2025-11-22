using Marketplace.Application.Interfaces;
using Marketplace.Domain;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly DatabaseManager _context;

    public ItemRepository(DatabaseManager context)
    {
        _context = context;
    }
    public async Task<Item?> GetItemByIdAsync(int id)
    {
        return await _context.Items.FirstOrDefaultAsync(i => i.id == id);
    }

    public async Task<IEnumerable<Item>> GetAllItemAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task AddItemAsync(Item item)
    {
        await _context.Items.AddAsync(item);
    }

    public Task RemoveItemAsync(Item item)
    {
        _context.Items.Remove(item);
        return Task.CompletedTask;
    }

    public Task BuyItemAsync(Item item)
    {
        _context.Items.Update(item);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}