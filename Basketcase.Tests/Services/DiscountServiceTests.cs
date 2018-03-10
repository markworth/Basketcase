using System.Collections.Generic;
using Basketcase.Core.Models;
using Basketcase.Core.Services;
using Basketcase.Core.Services.DiscountRules;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests.Services
{
    [TestFixture]
    public class DiscountServiceTests
    {
        private DiscountService _discountService;
        private Mock<IDiscountRule> _discountRule1;
        private Mock<IDiscountRule> _discountRule2;

        [SetUp]
        public void Setup()
        {
            _discountRule1 = new Mock<IDiscountRule>();
            _discountRule2 = new Mock<IDiscountRule>();

            _discountService = new DiscountService(new[] { _discountRule1.Object, _discountRule2.Object });
        }

        [Test]
        public void Given1OfTheRulesReturnADiscount_WhenIGetTheDiscounts_ThenThereIs1Discount()
        {
            var basketItems = new List<BasketItem>();

            _discountRule1.Setup(x => x.CalculateDiscount(It.Is<List<BasketItem>>(b => b == basketItems))).Returns(new Discount() { Product = ProductNames.BREAD });
            _discountRule2.Setup(x => x.CalculateDiscount(It.Is<List<BasketItem>>(b => b == basketItems))).Returns((Discount)null);

            var discounts = _discountService.GetDiscounts(basketItems);

            discounts.Count.ShouldBe(1);
            discounts[0].Product.ShouldBe(ProductNames.BREAD);
        }

        [Test]
        public void GivenNeitherOfTheRulesReturnADiscount_WhenIGetTheDiscounts_ThenThereIsNoDiscounts()
        {
            _discountRule1.Setup(x => x.CalculateDiscount(It.IsAny<List<BasketItem>>())).Returns((Discount)null);
            _discountRule2.Setup(x => x.CalculateDiscount(It.IsAny<List<BasketItem>>())).Returns((Discount)null);

            var discounts = _discountService.GetDiscounts(new List<BasketItem>());

            discounts.Count.ShouldBe(0);
        }
    }
}
