using System;
using System.Collections.Generic;
using System.Text;
using Basketcase.Core.Models;

namespace Basketcase.Core.Services.DiscountRules
{
    public interface IDiscountRule
    {
        Discount CalculateDiscount(IList<BasketItem> products);
    }
}
