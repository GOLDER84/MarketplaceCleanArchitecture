
using Marketplace.Domain;

namespace Service;

public interface IUserService
{
    Task<string> RegisterAsync(string name ,string username , string password , int age , double credit , string email);
    Task<string> LoginAsync(string username , string password);
    Task<string> EditAsync(string name ,string username , string password , int age , string email); 
    Task<string> AddCreditAsync(string username , double amount);
    Task<User?> GetUserByNameAsync(string name);
    Task<string> GetAllUsersAsync();
}