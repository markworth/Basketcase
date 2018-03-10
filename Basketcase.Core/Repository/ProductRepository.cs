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
        private Dictionary<string, Product> _product = new Dictionary<string, Product>()
        {
            {  ProductNames.BUTTER, new Product() { Name = ProductNames.BREAD, Cost = 0.8M } },
            {  ProductNames.MILK, new Product() { Name = ProductNames.MILK, Cost = 1.15M } },
            {  ProductNames.BREAD, new Product() { Name = ProductNames.BREAD, Cost = 1 } },
        };

        public Product GetProduct(string name)
        {
            return _product[name];
        }
    }
}
