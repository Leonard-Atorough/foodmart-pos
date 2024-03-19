using FoodMart.POS.Shared.Models.Interfaces;

namespace FoodMart.POS.Shared.Models
{
    public class BasketItem : IBasketItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public BasketItem(int id, string name, int count)
        {
            Id = id;
            Name = name;
            Count = count;
        }

        public void Update(bool isIncrement)
        {
            if (isIncrement)
            {
                Count++;
                return;
            }

            Count--;
        }
    }
}