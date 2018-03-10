using System.Collections.Generic;
using Basketcase.Core.Models;
using Basketcase.Core.Repository;
using Basketcase.Core.Services;
using Basketcase.Core.Services.DiscountRules;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace Basketcase.Tests.Services
{
    [TestFixture]
    public class BasketServiceTests
    {
        private BasketService _basketService;
        private Mock<IProductRepository> _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
            _basketService = new BasketService(_productRepository.Object);
        }

        [Test]
        public void GivenThereAreNoDiscounts_WhenTheTotalIsCalculated_ThenTheFullPriceShouldBeCalculated()
        {
            var bread = new BasketItem() {Name = ProductNames.BREAD, Quantity = 2};

            _productRepository.Setup(x => x.GetProduct(bread.Name)).Returns(new Product() { Name = bread.Name, Cost = 42.42M});

            var items = new List<BasketItem>() { bread };

            _basketService.Total(items, new List<Discount>()).ShouldBe(84.84M);
        }

        [Test]
        public void GivenThereIsADiscount_WhenTheTotalIsCalculated_ThenTheDiscountShouldBeCalculated()
        {
            var bread = new BasketItem() { Name = ProductNames.BREAD, Quantity = 2 };
            var butter = new BasketItem() { Name = ProductNames.BUTTER, Quantity = 3 };

            _productRepository.Setup(x => x.GetProduct(bread.Name)).Returns(new Product() { Name = bread.Name, Cost = 10 });
            _productRepository.Setup(x => x.GetProduct(butter.Name)).Returns(new Product() { Name = butter.Name, Cost = 20 });

            var items = new List<BasketItem>() { bread, butter };
            var discount = new Discount() { Percentage = 25, Product = bread.Name, QualifyingProducts = 2 };

            _basketService.Total(items, new List<Discount>() { discount }).ShouldBe(75);
        }
    }
}
