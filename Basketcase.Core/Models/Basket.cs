using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketcase.Core.Models
{
    public class Basket
    {
        private IList<BasketItem> basketItems = new List<BasketItem>();

        public void AddProduct(string productName)
        {
            var existingProduct = basketItems.FirstOrDefault(x => x.Name == productName);
            if (existingProduct == null)
            {
                basketItems.Add(new BasketItem() { Name = productName, Quantity = 1 });
            }
            else
            {
                existingProduct.Quantity = existingProduct.Quantity + 1;
            }
        }

        public void ChangeQuantity(string productName, int quantity)
        {
            throw new NotImplementedException();
        }

        public IList<BasketItem> Items => new List<BasketItem>(basketItems);
    }
}
