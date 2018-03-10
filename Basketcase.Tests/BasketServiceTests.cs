using Basketcase.Core.Models;
using Basketcase.Core.Repository;
using Basketcase.Core.Services;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests
{
    [TestFixture]
    public class BasketServiceTests
    {
        private BasketService _basketService;

        [SetUp]
        public void Setup()
        {
            _basketService = new BasketService(new ProductRepository());
        }

        [Test]
        public void GivenABasketWith1Bread1Butter1Milk_WhenTheTotalIsCalculated_ThenTheCorrectTotalIsReturned()
        {
            var basket = new Basket();

            basket.AddProduct(ProductNames.BREAD);
            basket.AddProduct(ProductNames.MILK);
            basket.AddProduct(ProductNames.BUTTER);

            var discounts = new DiscountService().GetDiscounts(basket.Items);
            var total = _basketService.Total(basket.Items, discounts);

            total.ShouldBe(2.95M);
        }
    }
}
