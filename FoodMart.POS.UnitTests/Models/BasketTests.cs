using FoodMart.POS.Shared.Models;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.UnitTests.Models
{
    internal class BasketTests
    {
        private Basket basket;

        [SetUp]
        public void SetUp() 
        {
            basket = new Basket();

            basket.BasketItems.Add(new BasketItem(1, "Bread", 1));
            basket.BasketItems.Add(new BasketItem(2, "Cheese", 5));
            basket.BasketItems.Add(new BasketItem(3, "Apples", 1));
            basket.BasketItems.Add(new BasketItem(4, "Honey", 2));
            basket.BasketItems.Add(new BasketItem(5, "Milk", 3));
        }

        [Test]
        public void When_A_New_Item_Is_Added_To_The_Basket_Then_The_Count_Of_BasketItems_Increases_By_One()
        {
            var preCount = basket.BasketItems.Count;

            Item itemToAdd = new(6, "Coffee", null!, 12.0m);
            basket.AddItemToBasket(itemToAdd);

            var countDiff = basket.BasketItems.Count - preCount;
            Assert.Multiple(() =>
            {
                Assert.That(countDiff, Is.EqualTo(1));
                Assert.That(basket.BasketItems, Has.Count.EqualTo(preCount + 1));
                Assert.That(basket.BasketItems.Last().Id, Is.EqualTo(itemToAdd.Id));
                Assert.That(basket.BasketItems.Last().Name, Is.EqualTo(itemToAdd.ItemName));
            });
        }

        [Test]
        public void When_An_Existing_Item_Is_Added_To_The_Basket_Then_Count_For_That_Item_Is_Increased_By_One()
        {
            var preCount = basket.BasketItems.Count;
            var ItemToAdd = new Item(5, "Milk", null!, 2);

            basket.AddItemToBasket(ItemToAdd);

            Assert.Multiple(() =>
            {
                Assert.That(basket.BasketItems, Has.Count.EqualTo(preCount));
                Assert.That(basket.BasketItems[4].Name, Is.EquivalentTo("Milk"));
                Assert.That(basket.BasketItems[4].Count, Is.EqualTo(4));
            });
        }

        [TestCase(3, "Milk", 2)]
        [TestCase(1, "Honey", 5)]
        public void When_An_Attempt_Is_Made_To_Add_An_Existing_item_And_The_Item_To_Add_Details_Do_Not_Match_Then_An_Exception_Is_Thrown(
            int id,
            string name,
            int price)
        {
            var ItemToAdd = new Item(id, name, null!, price);

            Assert.That(() => { basket.AddItemToBasket(ItemToAdd); }, Throws.TypeOf<InvalidOperationException>());
        }
    }
}
