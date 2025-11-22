namespace Mraketplace.Presention.DTOs.RequestModels;

public class RegisterRequestModel
{
    public string name { get; }
    public string username { get; }
    public string password { get; }
    public int age { get; }
    public double credit { get; }
    public string email { get; }

    public RegisterRequestModel(string name, string username, string password, int age, double credit, string email)
    {
        this.name = name;
        this.username = username;
        this.password = password;
        this.age = age;
        this.credit = credit;
        this.email = email;
    }
}