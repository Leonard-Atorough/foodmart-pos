namespace FoodMart.POS.Shared.Models.Interfaces
{
    public interface IBasketItem
    {
        int Count { get; set; }
        int Id { get; set; }
        string Name { get; set; }

        void Update(bool isIncrement);
    }
}