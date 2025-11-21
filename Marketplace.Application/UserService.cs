using Marketplace.Domain;
using Service.Interfaces.Repsitoreis;

namespace Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<string> RegisterAsync(string name, string username, string password, int age, double credit, string email)
    {
        if (await _userRepository.ExistsUserAsync(name))
        {
            return "User with same name already exists";
        }
        var user = new User(name, username, password, age, credit, email);
        await _userRepository.AddUserAsync(user);
        await _userRepository.SaveAsync();
        return "User created";
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var user = await _userRepository.GetUserByUserNameAsync(username);
        if (user != null && user.password == password)
        {
            return "Login successful";
        }
        return "Invalid username or password";
    }


    public async Task<string> EditAsync(string name, string username, string password, int age, string email)
    {
        var user = await _userRepository.GetUserByUserNameAsync(username);
        if (user != null)
        {
            user.name = name;
            user.password = password;
            user.age = age;
            user.email = email;
            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
            return "User updated successfully";
        }
        else
        {
            return "User not found";
        }
    }

    public async Task<string> AddCreditAsync(string username, double amount)
    {
        var user = await _userRepository.GetUserByUserNameAsync(username);
        if (user != null)
        {
            user.credit += amount;
            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveAsync();
            return "Credit added successfully";
        }
        else
        {
            return "User not found";
        }
    }

    public async Task<User?> GetUserByNameAsync(string name)
    {
        return await _userRepository.GetUserByUserNameAsync(name);
    }

    public async Task<string> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllUsersAsync();
        if (users.Any())
        {
            return string.Join(Environment.NewLine, users.Select(u => $"Name: {u.name}, Username: {u.username}, Age: {u.age}, Credit: {u.credit}, Email: {u.email}"));
        }
        return "No users found";
    }
}