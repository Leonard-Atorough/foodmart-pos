using FoodMart.POS.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS.UnitTests.Models
{
    public class ItemTest
    {
        [Test]
        public void Given_An_Item_Is_Constructed_And_All_The_Parameters_Are_Supplied()
        {
            var item = new Item(1, "Beef", "It is beef", 12.0m);
            Assert.IsNotNull(item);
            Assert.That(item.Id, Is.EqualTo(1));
            Assert.That(item.ItemName, Is.EqualTo("Beef"));
            Assert.That(item.ItemDescription, Is.EqualTo("It is beef"));
            Assert.That(item.ItemPrice, Is.EqualTo(12.0m));
        }

        [Test]
        public void Given_An_Item_Is_Constructed_And_All_The_Description_Is_Not_Supplied_Then_The_Default_Description_Is_Used()
        {
            var item = new Item(2, "Milk", null!, 2.5m);
            Assert.IsNotNull(item);
            Assert.That(item.Id, Is.EqualTo(2));
            Assert.That(item.ItemName, Is.EqualTo("Milk"));
            Assert.That(item.ItemDescription, Is.EqualTo("No description provided."));
            Assert.That(item.ItemPrice, Is.EqualTo(2.5m));
        }

        [Test]
        public void Given_An_Item_Is_Constructed_And_A_Name_Is_Not_Supplied_Then_An_Excpetion_Is_Thrown()
        {
            Assert.That(() => new Item(2, null!, "This is milk", 2.5m), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
