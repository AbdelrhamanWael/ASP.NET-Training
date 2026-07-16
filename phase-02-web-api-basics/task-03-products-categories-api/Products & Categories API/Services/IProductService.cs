using Products___Categories_API.DTOs;
using Products___Categories_API.Models;
using Products___Categories_API.Models.DTOs;

namespace Products___Categories_API.Services
{
    public interface IProductService
    {
        ProductResponse? Create(CreateProductRequest request);
        IEnumerable<ProductResponse> GetAll(string? search, int? categoryId, decimal? minPrice, decimal? maxPrice, bool? isAvailable);
        ProductResponse? GetById(int id);
        ProductResponse? Update(int id, UpdateProductRequest request);
        ProductResponse? UpdateStock(int id, int newQuantity);
        bool Delete(int id);
        IEnumerable<ProductResponse> GetLowStock(int threshold);
        StockValueReportResponse GetStockValueReport();
    }
}
