using System.Collections.Generic;
using System.Linq;
using Basketcase.Core.Models;

namespace Basketcase.Core.Services.DiscountRules
{
    public class BreadButterRule : IDiscountRule
    {
        public Discount CalculateDiscount(IList<BasketItem> products)
        {
            Discount discount = null;
            
            var butter = products.FirstOrDefault(x => x.Name == ProductNames.BUTTER)?.Quantity ?? 0;
            if (butter >= 2)
            {
                discount = new Discount()
                {
                    Product = ProductNames.BREAD,
                    Percentage = 50,
                    QualifyingProducts = butter / 2
                };
            }

            return discount;
        }
    }
}
