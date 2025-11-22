using Marketplace.Domain;

namespace Mraketplace.Presention.DTOs.ResponseModels;

public class UserSummaryResponseModel
{
    public string Name { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public int Age { get; set; }
    public double Credit { get; set; }
    public string Email { get; set; } = string.Empty;

    public UserSummaryResponseModel() { }

    public UserSummaryResponseModel(string name, string username, int age, double credit, string email)
    {
        Name = name;
        Username = username;
        Age = age;
        Credit = credit;
        Email = email;
    }

    public static UserSummaryResponseModel? FromDomain(User? user)
    {
        if (user == null) return null;

        return new UserSummaryResponseModel(
            name: user.name ?? string.Empty,
            username: user.username ?? string.Empty,
            age: user.age,
            credit: user.credit,
            email: user.email ?? string.Empty
        );
    }
    
    public string ToSummaryString()
    {
        return $"{Name} ({Username}) - Age: {Age}, Credit: {Credit:F2}, Email: {Email}";
    }
}