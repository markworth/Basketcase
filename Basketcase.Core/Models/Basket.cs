using System;
using System.Collections.Generic;
using System.Text;

namespace Basketcase.Core.Models
{
    public class Basket
    {
        private IList<BasketItem> basketItems = new List<BasketItem>();

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IList<BasketItem> Items => new List<BasketItem>(basketItems);
    }
}
