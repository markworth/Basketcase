using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }
    }
}
