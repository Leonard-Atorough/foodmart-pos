using FoodMart.POS.Shared.AggregateEntities;
using FoodMart.POS.Shared.AggregateEntities.BasketAggregate;
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
        }

        [Test]
        public void When_A_New_Item_Is_Added_To_The_Basket_Then_The_Count_Of__items_Increases_By_One()
        {
            var preCount = basket.Items.Count;

            Item itemToAdd = new("Coffee", string.Empty, 12.0m);
            basket.AddItemToBasket(itemToAdd);

            Assert.Multiple(() =>
            {
                Assert.That(basket.Items, Has.Count.EqualTo(1));
                Assert.That(basket.Items.Last().Name, Is.EqualTo(itemToAdd.ItemName));
            });
        }

        [Test]
        public void When_An_Existing_Item_Is_Added_To_The_Basket_Then_Count_For_That_Item_Is_Increased_By_One()
        {
            var ItemToAdd = new Item("Milk", string.Empty, 2);
            basket.AddItemToBasket(ItemToAdd);
            var preCount = basket.Items.Count;
            basket.AddItemToBasket(ItemToAdd);

            Assert.Multiple(() =>
            {
                Assert.That(basket.Items, Has.Count.EqualTo(preCount));
                Assert.That(basket.Items.Select(x => x.Name).ToList(), Does.Contain("Milk"));
                Assert.That(basket.Items.Select(x => x.Name == "Milk").Count, Is.EqualTo(1));
            });
        }
    }
}
