using System.ComponentModel.DataAnnotations;

namespace Marketplace.Domain;

public class User
{
    
    [Key]
    public int id {get; set;}
    
    // static int ID_USER_COUNTER = 1;
    public string name {get; set;}
    public string username {get; set;}
    public string password {get; set;}
    public int age {get; set;}
    public double credit {get; set;}
    public string email {get; set;}

    public User(string name, string username, string password, int age, double credit, string email)
    {
        this.name = name;
        this.username = username;
        this.password = password;
        this.age = age;
        this.credit = credit;
        this.email = email;
    }

    private User()
    {
        
    }
    //
    public void AddCredit(double amount)
    {
        if (amount > 0)
        {
            this.credit += amount;
        }
    }

    public void UpdateProfile(string name, int age, double credit, string email)
    {
        this.name = name;
        this.age = age;
        this.credit = credit;
        this.email = email;
    }
    //

}