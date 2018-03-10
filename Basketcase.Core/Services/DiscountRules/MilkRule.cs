using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basketcase.Core.Models;

namespace Basketcase.Core.Services.DiscountRules
{
    public class MilkRule : IDiscountRule
    {
        public Discount CalculateDiscount(IList<BasketItem> products)
        {
            Discount discount = null;

            var milk = products.FirstOrDefault(x => x.Name == ProductNames.MILK)?.Quantity ?? 0;
            if (milk >= 4)
            {
                discount = new Discount()
                {
                    Product = ProductNames.MILK,
                    Percentage = 100,
                    QualifyingProducts = milk / 4
                };
            }

            return discount;
        }
    }
}
