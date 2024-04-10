using FoodMart.POS.Shared.SeedWork;

namespace FoodMart.POS.Shared.AggregateEntities.BasketAggregate
{
    public class Basket: BaseEntity, IAggreateRoot
    {
        private readonly List<BasketItem> _items = [];
        public IReadOnlyCollection<BasketItem> Items => _items.AsReadOnly();

        public void AddItemToBasket(Item item)
        {
            var itemInBasket = _items.FirstOrDefault(b => b.ItemId == item.Id);
            switch (itemInBasket)
            {
                case null:
                    _items.Add(new BasketItem(item.ItemName, 1, item.Id));
                    break;
                default:
                    if (itemInBasket.Name != item.ItemName)
                    {
                        throw new InvalidOperationException($"The item ID value {item.Id} and the item name value {item.ItemName} do not match. Please validate input");
                    }
                    itemInBasket.Update(true);
                    break;
            }
        }

        public void RemoveItemFromBasket(int itemId, string itemName)
        {
            if (!_items.Any(x => x.Id == itemId && x.Name == itemName))
            {
                return;
            }
            _items.First(x => x.Id == itemId).Update(false);

            var emptyItems = _items.Where(i => i.Count <= 0).ToList();

            if (emptyItems.Count != 0)
            {
                ClearEmptyItems(emptyItems);
            }
        }

        private void ClearEmptyItems(IEnumerable<BasketItem> emptyItems) => emptyItems.ToList().RemoveAll(x => x.Count <= 0);
    }
}
