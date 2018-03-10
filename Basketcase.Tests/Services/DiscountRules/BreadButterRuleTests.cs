using System.Collections.Generic;
using Basketcase.Core.Models;
using Basketcase.Core.Services.DiscountRules;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests.Services.DiscountRules
{
    [TestFixture]
    public class BreadButterRuleTests
    {
        private BreadButterRule _breadButterRule;

        [SetUp]
        public void Setup()
        {
            _breadButterRule = new BreadButterRule();
        }

        [Test]
        public void GivenNoButter_WhenDiscountsAreCalculated_ThenNoDiscount()
        {
            var basketItems = new List<BasketItem>();
            var discount = _breadButterRule.CalculateDiscount(basketItems);

            discount.ShouldBeNull();
        }

        [Test]
        public void Given2Butter_WhenDiscountsAreCalculated_ThenABreadIs50PercentOff()
        {
            var basketItems = new List<BasketItem>()
            {
                new BasketItem() { Name = ProductNames.BUTTER, Quantity = 2 }
            };

            var discount = _breadButterRule.CalculateDiscount(basketItems);

            discount.ShouldNotBeNull();
            discount.Product.ShouldBe(ProductNames.BREAD);
            discount.Percentage.ShouldBe(50);
            discount.QualifyingProducts.ShouldBe(1);
        }

        [Test]
        public void Given4Butter_WhenDiscountsAreCalculated_Then2BreadAre50PercentOff()
        {
            var basketItems = new List<BasketItem>()
            {
                new BasketItem() { Name = ProductNames.BUTTER, Quantity = 4 }
            };

            var discount = _breadButterRule.CalculateDiscount(basketItems);

            discount.ShouldNotBeNull();
            discount.Product.ShouldBe(ProductNames.BREAD);
            discount.Percentage.ShouldBe(50);
            discount.QualifyingProducts.ShouldBe(2);
        }
    }
}
