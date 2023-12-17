using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.Shared
{
    public class POSService
    {
        public Dictionary<string, decimal> Basket { get; private set; }
        public decimal Total { get; private set; }
        public decimal Payment { get; private set; }
        public decimal Change { get; private set; }

        public POSService()
        {
            Basket = [];
        }


        public bool ScanItem(string item, out string currentBasket)
        {
            var sb = new StringBuilder();
            var value = InventoryAccess.GetItemPrice(item);
            if (value != 0m)
            {
                if (!Basket.TryAdd(item, value))
                {
                    Basket[item] += value;
                }

                Total += value;
                PrintScannedItems(sb);
                currentBasket = sb.ToString();
                return true;
            }
            PrintScannedItems(sb);
            currentBasket = sb.ToString();
            return false;

        }

        public string ProcessPayment(decimal paymentAmount)
        {
            Payment = paymentAmount;
            Change = paymentAmount - Total;
            return PrintReceipt();
        }

        public string PrintReceipt()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Food Mart Limited");
            sb.AppendLine("=================\r\n");
            PrintScannedItems(sb);
            sb.AppendLine($"PAID: {Payment}\r\n");
            sb.AppendLine($"CHANGE: {Change}\r\n");
            sb.AppendLine("Have a lovely day!");

            return sb.ToString();
        }

        private void PrintScannedItems(StringBuilder sb)
        {
            foreach (var item in Basket)
            {
                sb.AppendLine($"{item.Key} {item.Value}");
            }
            sb.AppendLine();
            sb.AppendLine($"TOTAL: {Total}\r\n");

        }
    }
}
