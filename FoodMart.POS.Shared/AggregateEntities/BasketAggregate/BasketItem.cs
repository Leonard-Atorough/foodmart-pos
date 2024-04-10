using FoodMart.POS.Shared.SeedWork;

namespace FoodMart.POS.Shared.AggregateEntities.BasketAggregate
{
    public class BasketItem : BaseEntity
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int ItemId { get; set; }

        public BasketItem(string name, int count, int itemId)
        {
            Name = name;
            Count = count;
            ItemId = itemId;
        }

        public void Update(bool increment)
        {
            if (increment)
            {
                Count++;
                return;
            }

            Count--;
        }
    }
}