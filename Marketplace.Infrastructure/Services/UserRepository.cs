using Marketplace.Application.Interfaces;
using Marketplace.Domain;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using Service.Interfaces.Repsitoreis;

namespace Marketplace.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseManager _context;

    public UserRepository(DatabaseManager context)  
    {
        _context = context;
    }

    public async Task<User?> GetUserByUserNameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.username == username);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.id == id);
    }

    public async Task<bool> ExistsUserAsync(string username)
    {
        return await _context.Users.AnyAsync(u => u.username == username);
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public Task UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        return Task.CompletedTask;
    }

    public Task SaveAsync()
    {
        return _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }
}