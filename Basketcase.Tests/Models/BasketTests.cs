using System.Linq;
using Basketcase.Core.Models;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests.Models
{
    [TestFixture]
    public class BasketTests
    {
        private Basket _basket;

        [SetUp]
        public void Setup()
        {
            _basket = new Basket();
        }

        [Test]
        public void GivenAProductIsAdded_WhenItemsAreRetrieved_ThenTheQuantityIs1()
        {
            _basket.AddProduct(ProductNames.BREAD);

            _basket.Items.Count.ShouldBe(1);
            _basket.Items[0].Name.ShouldBe(ProductNames.BREAD);
            _basket.Items[0].Quantity.ShouldBe(1);
        }

        [Test]
        public void GivenAProductIsAddedTwice_WhenItemsAreRetrieved_ThenTheQuantityIs2()
        {
            _basket.AddProduct(ProductNames.BREAD);
            _basket.AddProduct(ProductNames.BREAD);

            _basket.Items.Count.ShouldBe(1);
            _basket.Items[0].Name.ShouldBe(ProductNames.BREAD);
            _basket.Items[0].Quantity.ShouldBe(2);
        }

        [Test]
        public void GivenAProductIsAddedWithAQuantityOf2_WhenItemsAreRetrieved_ThenTheQuantityIs2()
        {
            _basket.AddProduct(ProductNames.BREAD, 2);

            _basket.Items.Count.ShouldBe(1);
            _basket.Items[0].Name.ShouldBe(ProductNames.BREAD);
            _basket.Items[0].Quantity.ShouldBe(2);
        }

        [Test]
        public void GivenTwoProductsAreAdded_WhenItemsAreRetrieved_ThenTheQuantityForBothIs1()
        {
            _basket.AddProduct(ProductNames.BREAD);
            _basket.AddProduct(ProductNames.MILK);

            _basket.Items.Count.ShouldBe(2);

            _basket.Items.Count(x => x.Name == ProductNames.BREAD).ShouldBe(1);
            _basket.Items.First(x => x.Name == ProductNames.BREAD).Quantity.ShouldBe(1);

            _basket.Items.Count(x => x.Name == ProductNames.MILK).ShouldBe(1);
            _basket.Items.First(x => x.Name == ProductNames.MILK).Quantity.ShouldBe(1);
        }
    }
}
