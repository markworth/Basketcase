using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basketcase.Core.Models;
using Basketcase.Core.Repository;

namespace Basketcase.Core.Services
{
    public class BasketService
    {
        private IProductRepository _productRepository;

        public BasketService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public decimal Total(IList<BasketItem> items, IList<Discount> discounts)
        {
            decimal total = 0;

            foreach (var item in items)
            {
                var product = _productRepository.GetProduct(item.Name);

                var correspondingDiscount = discounts.FirstOrDefault(x => x.Product == item.Name);
                int quantityAtDiscountPrice = correspondingDiscount?.QualifyingProducts ?? 0;
                int percentageDiscount = correspondingDiscount?.Percentage ?? 0;

                // Add normal priced goods to total
                total += (item.Quantity - quantityAtDiscountPrice) * product.Cost;

                // Add discount priced goods to total
                total += quantityAtDiscountPrice * product.Cost * (100 - percentageDiscount) / 100;
            }

            return total;
        }
    }
}
