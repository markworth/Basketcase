using System;
using System.Collections.Generic;
using System.Text;
using Basketcase.Core.Models;

namespace Basketcase.Core.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(string name);
    }

    public class ProductRepository : IProductRepository
    {
        public Product GetProduct(string name)
        {
            throw new NotImplementedException();
        }
    }
}
