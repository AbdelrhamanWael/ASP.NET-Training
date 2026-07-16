using RefactoredApi.DTOs;
using System.Collections.Generic;

namespace RefactoredApi.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponse> GetAllProducts();
        ProductResponse? GetProductById(int id);
        ProductResponse AddProduct(CreateProductRequest request);
    }
}
