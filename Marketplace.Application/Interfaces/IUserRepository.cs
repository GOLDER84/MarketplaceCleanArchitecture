using Marketplace.Domain;

namespace Service.Interfaces.Repsitoreis;

public interface IUserRepository
{
    Task<User?> GetUserByUserNameAsync(string username);
    Task<User?> GetUserByIdAsync(int id);
    Task<bool> ExistsUserAsync(string username);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task SaveAsync();
    Task<IEnumerable<User>> GetAllUsersAsync();
}