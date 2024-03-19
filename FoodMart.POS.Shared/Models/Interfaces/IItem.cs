namespace FoodMart.POS.Shared.Models.Interfaces
{
    public interface IItem
    {
        int Id { get; set; }
        string? ItemDescription { get; set; }
        string ItemName { get; set; }
        decimal ItemPrice { get; set; }
    }
}