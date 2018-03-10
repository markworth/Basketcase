using System;
using System.Collections.Generic;
using System.Text;

namespace Basketcase.Core.Models
{
    public class BasketItem
    {
        public BasketItem(string name, decimal costPerItem, int quantity)
        {
            Name = name;
            CostPerItem = costPerItem;
            Quantity = quantity;
        }

        public string Name { get; }
        public decimal CostPerItem { get; }
        public int Quantity { get; }
    }
}
