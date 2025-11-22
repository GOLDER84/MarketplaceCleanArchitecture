using Marketplace.Domain;

namespace Mraketplace.Presention.DTOs.ResponseModels;

public class ItemSummaryResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }

    public static ItemSummaryResponseModel? FromDomain(Item? item)
    {
        if (item == null) return null;
        return new ItemSummaryResponseModel
        {
            Id = item.id,
            Name = item.name,
            Price = item.price,
            Description = item.description
        };
    }
}