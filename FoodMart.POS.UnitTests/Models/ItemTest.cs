using FoodMart.POS.Shared.AggregateEntities;

namespace FoodMart.POS.UnitTests.Models
{
    public class ItemTest
    {
        [Test]
        public void Given_An_Item_Is_Constructed_And_All_The_Parameters_Are_Supplied()
        {
            var item = new Item("Beef", "It is beef", 12.0m);
            Assert.IsNotNull(item);
            Assert.That(item.ItemName, Is.EqualTo("Beef"));
            Assert.That(item.ItemDescription, Is.EqualTo("It is beef"));
            Assert.That(item.ItemPrice, Is.EqualTo(12.0m));
        }

        [Test]
        public void Given_An_Item_Is_Constructed_And_All_The_Description_Is_Not_Supplied_Then_The_Default_Description_Is_Used()
        {
            var item = new Item("Milk", null!, 2.5m);
            Assert.IsNotNull(item);
            Assert.That(item.ItemName, Is.EqualTo("Milk"));
            Assert.That(item.ItemDescription, Is.EqualTo("No description provided."));
            Assert.That(item.ItemPrice, Is.EqualTo(2.5m));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Given_An_Item_Is_Constructed_And_A_Name_Is_Not_Supplied_Then_An_Excpetion_Is_Thrown(string name)
        {
            Assert.Catch<ArgumentException>(() => new Item(name, string.Empty, 2.5m));
        }
    }
}
