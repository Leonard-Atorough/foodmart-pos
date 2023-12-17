using FoodMart.POS.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.UnitTests
{
    public class Scenarios
    {
        [TestCase("Coffee", "3.25")]
        [TestCase("coffee", "3.25")]
        [TestCase("Sugar", "0")]
        public void GivenIGetAnItemFromTheDatabaseThenIGetThePrice(string item, decimal expected)
        {
            var result = InventoryAccess.GetItemPrice(item);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GivenIScanInAnItemThenTheItemIsAddedToMyBasket()
        {
            POSService service = new();
            service.ScanItem("Coffee", out var currentBasket);

            Assert.That(service.Basket, Has.Count.EqualTo(1));
            Assert.That(service.Basket, Contains.Key("Coffee"));
            Assert.That(service.Basket["Coffee"], Is.EqualTo(3.25m));
        }

        [Test]
        public void GivenIScanAnItemAndItIsNotInTheInventoryThenItIsNotAddedToMyBasket()
        {
            POSService service = new();
            service.ScanItem("Potato", out var currentBasket);

            Assert.That(service.Basket, Has.Count.EqualTo(0));
        }

        [TestCase("Coffee", "3.25")]
        [TestCase("Tea", "2.20")]
        [TestCase("Electronics", "4.30")]
        public void GivenIScanMultipleOfTheSameItem_AndTheItemIsInInventory_ThenTheItemIsAddedToMyBasket_AndTheItemTotalIsCorrect(string item, decimal itemCost)
        {
            POSService service = new();
            var expectedTotal = itemCost * 3;
            for (int i = 0; i < 3; i++)
            {
                service.ScanItem(item, out var currentBasket);
            }

            Assert.That(service.Basket, Has.Count.EqualTo(1));
            Assert.That(service.Basket, Contains.Key(item));
            Assert.That(service.Basket[item], Is.EqualTo(expectedTotal));
        }

        [Test]
        public void GivenIScanMultipleDifferentItems_AndTheItemsAreInInventory_ThenTheItemsAreAddedToMyBasket_AndTheBaketTotalIsCorrect()
        {
            POSService service = new();
            service.ScanItem("Coffee", out _);
            service.ScanItem("Milk", out _);
            service.ScanItem("Soap", out _);

            Assert.That(service.Basket, Has.Count.EqualTo(3));
            Assert.That(service.Total, Is.EqualTo(6.8m));
        }

        [Test]
        public void GivenIHaveAddedMultipleItemsIntoMyBasket_WhenIPayWithAGivenAmount_ThenIGetCorrectChange()
        {
            POSService service = new();
            service.ScanItem("Coffee", out _);
            service.ScanItem("Milk", out _);
            service.ScanItem("Soap", out _);

            service.ProcessPayment(10.0m);

            Assert.That(service.Payment, Is.EqualTo(10.0m));
            Assert.That(service.Change, Is.EqualTo(3.2m));
        }
    }
}
