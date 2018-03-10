using System.Collections.Generic;
using Basketcase.Core.Models;
using Basketcase.Core.Repository;
using Basketcase.Core.Services;
using Basketcase.Core.Services.DiscountRules;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests
{
    [TestFixture]
    public class BasketCaseAcceptanceTests
    {
        private BasketService _basketService;
        private DiscountService _discountService;

        [SetUp]
        public void Setup()
        {
            _basketService = new BasketService(new ProductRepository());
            _discountService = new DiscountService(new List<IDiscountRule>() {new MilkRule(), new BreadButterRule()});
        }

        [Test]
        public void GivenABasketWith1Bread1Butter1Milk_WhenTheTotalIsCalculated_ThenTheCorrectTotalIsReturned()
        {
            var basket = new Basket();

            basket.AddProduct(ProductNames.BREAD);
            basket.AddProduct(ProductNames.MILK);
            basket.AddProduct(ProductNames.BUTTER);

            var discounts = _discountService.GetDiscounts(basket.Items);
            var total = _basketService.Total(basket.Items, discounts);

            total.ShouldBe(2.95M);
        }

        [Test]
        public void GivenABasketWith2Bread2Butter_WhenTheTotalIsCalculated_ThenTheCorrectTotalIsReturned()
        {
            var basket = new Basket();

            basket.AddProduct(ProductNames.BREAD, 2);
            basket.AddProduct(ProductNames.BUTTER, 2);

            var discounts = _discountService.GetDiscounts(basket.Items);
            var total = _basketService.Total(basket.Items, discounts);

            total.ShouldBe(3.1M);
        }

        [Test]
        public void GivenABasketWith4Milk_WhenTheTotalIsCalculated_ThenTheCorrectTotalIsReturned()
        {
            var basket = new Basket();

            basket.AddProduct(ProductNames.MILK, 4);

            var discounts = _discountService.GetDiscounts(basket.Items);
            var total = _basketService.Total(basket.Items, discounts);

            total.ShouldBe(3.45M);
        }

        [Test]
        public void GivenABasketWith1Bread2Butter8Milk_WhenTheTotalIsCalculated_ThenTheCorrectTotalIsReturned()
        {
            var basket = new Basket();

            basket.AddProduct(ProductNames.BREAD);
            basket.AddProduct(ProductNames.MILK, 8);
            basket.AddProduct(ProductNames.BUTTER, 2);

            var discounts = _discountService.GetDiscounts(basket.Items);
            var total = _basketService.Total(basket.Items, discounts);

            total.ShouldBe(9);
        }

    }
}
