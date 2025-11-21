using System.ComponentModel.DataAnnotations;
namespace Marketplace.Domain;

public class Item
{
    [Key]
    public int id {get; set;}
    
    // static int ID_ITEM_COUNTER = 1;
    public string name {get; set;}
    public double price {get; set;}
    public string description {get; set;}

    public Item(string name, double price, string description)
    {
        this.name = name;
        this.price = price;
        this.description = description;
    }

    private Item()
    {
        
    }

    public void UpdateDetails(string name, double price, string description)
    {
        this.name = name;
        this.price = price;
        this.description = description;
    }
}