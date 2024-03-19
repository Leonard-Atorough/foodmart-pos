using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMart.POS.Shared.Models.Interfaces;

namespace FoodMart.POS.Shared.Models
{
    public class Item : IItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public string? ItemDescription { get; set; } = string.Empty;
        public decimal ItemPrice { get; set; }

        public Item(int id, string itemName, string itemDescription, decimal itemPrice)
        {
            Id = id;
            ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
            ItemDescription = itemDescription ?? "No description provided.";
            ItemPrice = itemPrice;
        }
    }
}
