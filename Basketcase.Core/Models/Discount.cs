using System;
using System.Collections.Generic;
using System.Text;

namespace Basketcase.Core.Models
{
    public class Discount
    {
        public string Product { get; set; }
        public int Percentage { get; set; }
        public int QualifyingProducts { get; set; }
    }
}
