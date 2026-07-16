using RefactoredApi.DTOs;
using RefactoredApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RefactoredApi.Services
{
    public class ProductService : IProductService
    {
        private static readonly List<Product> _products = new List<Product>();

        public IEnumerable<ProductResponse> GetAllProducts()
        {
            return _products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock
            });
        }

        public ProductResponse? GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return null;
            }

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public ProductResponse AddProduct(CreateProductRequest request)
        {
            var product = new Product(
                _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1,
                request.Name,
                request.Price,
                request.Stock
            );

            _products.Add(product);

            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };
        }
    }
}
