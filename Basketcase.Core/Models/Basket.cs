using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketcase.Core.Models
{
    public class Basket
    {
        private IList<BasketItem> basketItems = new List<BasketItem>();

        public void AddProduct(string productName, int quantity = 1)
        {
            var existingProduct = basketItems.FirstOrDefault(x => x.Name == productName);
            if (existingProduct == null)
            {
                basketItems.Add(new BasketItem() { Name = productName, Quantity = quantity });
            }
            else
            {
                existingProduct.Quantity = existingProduct.Quantity + quantity;
            }
        }

        public void ChangeQuantity(string productName, int quantity)
        {
            throw new NotImplementedException();
        }

        public IList<BasketItem> Items => new List<BasketItem>(basketItems);
    }
}
