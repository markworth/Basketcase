using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basketcase.Core.Models;
using Basketcase.Core.Services.DiscountRules;

namespace Basketcase.Core.Services
{
    public class DiscountService
    {
        private readonly IList<IDiscountRule> _discountRules;

        public DiscountService(IList<IDiscountRule> discountRules)
        {
            _discountRules = discountRules;
        }

        public IList<Discount> GetDiscounts(IList<BasketItem> products)
        {
            var discounts = new List<Discount>();

            foreach (var rule in _discountRules)
            {
                var discountResult = rule.CalculateDiscount(products);

                if (discountResult != null)
                    discounts.Add(discountResult);
            }

            return discounts;
        }
    }
}
