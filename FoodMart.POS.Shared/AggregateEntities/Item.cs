using FoodMart.POS.Shared.SeedWork;

namespace FoodMart.POS.Shared.AggregateEntities
{
    public class Item : BaseEntity, IAggreateRoot
    {
        public string ItemName { get; set; } = string.Empty;
        public string? ItemDescription { get; set; } = string.Empty;
        public decimal ItemPrice { get; set; }

        public Item(string itemName, string itemDescription, decimal itemPrice)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(itemName, nameof(itemName));
            ItemName = itemName;
            ItemDescription = itemDescription ?? "No description provided.";
            ItemPrice = itemPrice;
        }
    }
}
