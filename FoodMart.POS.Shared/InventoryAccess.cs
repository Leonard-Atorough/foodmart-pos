using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Shared
{
    public static class InventoryAccess
    {
        public static Dictionary<string, decimal> Inventory { get; set; } = new(StringComparer.InvariantCultureIgnoreCase)
        {
            { "Bread" , 1.30m },
            { "Milk" , 1.45m },
            { "Tea" , 2.20m },
            { "Biscuits" , 1.99m },
            { "Crisps" , 0.50m },
            { "Electronics" , 4.30m },
            { "Ice Cream" , 0.99m },
            { "Sardines" , 1.15m },
            { "Soap" , 2.10m },
            { "Playing Cards" , 1.50m },
            { "Coffee" , 3.25m },
            { "Instant Ramen" , 5.10m },
        };

        public static string GetInventory()
        {
            var sb = new StringBuilder();
            var itemId = 1;
            foreach (var item in Inventory)
            {
                sb.AppendLine($"{itemId} -- {item.Key} -- £{item.Value}");
                itemId++;
            }

            return sb.ToString();
        }

        public static decimal GetItemPrice(string item)
        {
            _ = Inventory.TryGetValue(item, out var priceValue);
            return priceValue;
        }
    }
}
