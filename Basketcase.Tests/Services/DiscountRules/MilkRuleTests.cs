using System.Collections.Generic;
using Basketcase.Core.Models;
using Basketcase.Core.Services.DiscountRules;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests.Services.DiscountRules
{
    [TestFixture]
    public class MilkRuleTests
    {
        private MilkRule _breadButterRule;

        [SetUp]
        public void Setup()
        {
            _breadButterRule = new MilkRule();
        }

        [Test]
        public void GivenNoMilk_WhenDiscountsAreCalculated_ThenNoDiscount()
        {
            var basketItems = new List<BasketItem>();
            var discount = _breadButterRule.CalculateDiscount(basketItems);

            discount.ShouldBeNull();
        }

        [Test]
        public void Given4Milk_WhenDiscountsAreCalculated_ThenAMilkIs100PercentOff()
        {
            var basketItems = new List<BasketItem>()
            {
                new BasketItem() { Name = ProductNames.MILK, Quantity = 4 }
            };

            var discount = _breadButterRule.CalculateDiscount(basketItems);

            discount.ShouldNotBeNull();
            discount.Product.ShouldBe(ProductNames.MILK);
            discount.Percentage.ShouldBe(100);
            discount.QualifyingProducts.ShouldBe(1);
        }

        [Test]
        public void Given8Milk_WhenDiscountsAreCalculated_Then2MilkAre100PercentOff()
        {
            var basketItems = new List<BasketItem>()
            {
                new BasketItem() { Name = ProductNames.MILK, Quantity = 8 }
            };

            var discount = _breadButterRule.CalculateDiscount(basketItems);

            discount.ShouldNotBeNull();
            discount.Product.ShouldBe(ProductNames.MILK);
            discount.Percentage.ShouldBe(100);
            discount.QualifyingProducts.ShouldBe(2);
        }
    }
}
