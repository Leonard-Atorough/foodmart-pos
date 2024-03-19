using FoodMart.POS.Shared.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Shared.Models
{
    public class Basket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<BasketItem> BasketItems { get; set; } = [];


        public void AddItemToBasket(IItem item)
        {
            var itemInBasket = BasketItems.FirstOrDefault(b => b.Id == item.Id);
            if (itemInBasket == null)
            {
                BasketItems.Add(new BasketItem(item.Id, item.ItemName, 1));
            }
            else
            {
                if (itemInBasket.Name != item.ItemName)
                {
                    throw new InvalidOperationException($"The item ID value {item.Id} and the item name value {item.ItemName} do not match. Please validate input");
                }
                itemInBasket.Update(true);
            }
        }

        public void RemoveItemFromBasket(int itemId, string itemName)
        {
            if (!BasketItems.Any(x => x.Id == itemId && x.Name == itemName))
            {
                return;
            }
            BasketItems.First(x => x.Id == itemId).Update(false);
            
            var emptyItems = BasketItems.Where(i => i.Count <= 0).ToList();
            
            if (emptyItems.Count == 0)
            {
                ClearEmptyItems(emptyItems);
            }
        }

        private void ClearEmptyItems(IEnumerable<BasketItem> emptyItems) => emptyItems.ToList().RemoveAll(x => x.Count <= 0);
    }
}
