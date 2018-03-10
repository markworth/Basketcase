using Basketcase.Core.Models;
using Basketcase.Core.Services;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests
{
    [TestFixture]
    public class BasketServiceTests
    {
        private readonly Product BREAD = new Product() { Name = ProductNames.BREAD, Cost = 1 };
        private readonly Product MILK = new Product() { Name = ProductNames.MILK, Cost = 1.15M };
        private readonly Product BUTTER = new Product() { Name = ProductNames.BUTTER, Cost = 0.8M };


        [Test]
        public void GivenABasketWith1Bread1Butter1Milk_WhenTheTotalIsCalculated_ThenTheCorrectTotalIsReturned()
        {
            var basket = new Basket();

            basket.AddProduct(BREAD);
            basket.AddProduct(MILK);
            basket.AddProduct(BUTTER);

            var discounts = new DiscountService().GetDiscounts(basket.Items);
            var total = new BasketService().Total(basket.Items, discounts);

            total.ShouldBe(2.95M);
        }
    }
}
