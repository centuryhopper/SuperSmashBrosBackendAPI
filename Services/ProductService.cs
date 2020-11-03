using System.Collections.Generic;
using AspNetCoreWebAPI.Models;

namespace AspNetCoreWebAPI.Services
{
    // provides the list of products for the
    // product controller to handle
    public class ProductService
    {
        List<Product> _productList = null;
        public ProductService()
        {
            _productList = new List<Product>();
        }

        // getter
        public List<Product> GetProducts()
        {
            return _productList;
        }

        // setter
        public void AddProduct(Product product)
        {
            _productList.Add(product);
        }

        public void RemoveProduct(int idx)
        {
            _productList.RemoveAt(idx);
        }

        public bool IsEmpty()
        {
            return _productList.Count == 0;
        }
    }
}