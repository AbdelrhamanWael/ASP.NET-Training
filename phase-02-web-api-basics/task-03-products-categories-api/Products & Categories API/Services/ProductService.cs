using System;
using System.Collections.Generic;
using System.Linq;
using Products___Categories_API.DTOs;
using Products___Categories_API.Models;
using Products___Categories_API.Models.DTOs;
using Products___Categories_API.Services;


namespace ProductsCategoriesApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryService _categoryService;
        private static readonly List<Product> _products = new()
        {
            
            new Product(1, "Smartphone", 1, 699.99m, 12, "ElectroMax"),
            new Product(2, "Laptop Pro", 1, 1299.50m, 8, "ElectroMax"),
            new Product(3, "Wireless Headphones", 1, 149.99m, 25, "SoundSonic"),
            new Product(4, "Smartwatch", 1, 199.00m, 3, "WearTech"),
            new Product(5, "Bluetooth Speaker", 1, 79.99m, 0, "SoundSonic"),

            new Product(6, "Office Desk", 2, 249.99m, 5, "WoodCraft"),
            new Product(7, "Ergonomic Chair", 2, 189.50m, 10, "ComfortSeat"),
            new Product(8, "Bookshelf", 2, 120.00m, 2, "WoodCraft"),

            new Product(9, "Notebook A5", 3, 4.50m, 150, "PaperCo"),
            new Product(10, "Gel Pens Pack", 3, 8.99m, 85, "InkLine"),
            new Product(11, "Desk Organizer", 3, 19.99m, 14, "PaperCo"),
            new Product(12, "Stapler", 3, 6.50m, 4, "OfficeSupplies"),

            new Product(13, "Leather Wallet", 4, 45.00m, 20, "FashionHub"),
            new Product(14, "Backpack", 4, 59.99m, 15, "TravelStore"),
            new Product(15, "Sunglasses", 4, 120.00m, 1, "FashionHub")
        };
        private static int _nextId = 16;

        public ProductService(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ProductResponse? Create(CreateProductRequest request)
        {
            if (!_categoryService.Exists(request.CategoryId))
                throw new ArgumentException($"Category ID {request.CategoryId} does not exist or is inactive.");

            var product = new Product(
                _nextId++,
                request.Name,
                request.CategoryId,
                request.Price,
                request.StockQuantity,
                request.SupplierName
            );
            _products.Add(product);
            return MapToResponse(product);
        }

        public IEnumerable<ProductResponse> GetAll(string? search, int? categoryId, decimal? minPrice, decimal? maxPrice, bool? isAvailable)
        {
            var query = _products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || p.SupplierName.Contains(search, StringComparison.OrdinalIgnoreCase));

            if (categoryId.HasValue)
                query = query.Where(p => p.CategoryId == categoryId.Value);

            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            if (isAvailable.HasValue)
                query = query.Where(p => p.IsAvailable == isAvailable.Value);

            return query.Select(MapToResponse).ToList();
        }

        public ProductResponse? GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            return product == null ? null : MapToResponse(product);
        }

        public ProductResponse? Update(int id, UpdateProductRequest request)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return null;

            if (!_categoryService.Exists(request.CategoryId))
                throw new ArgumentException($"Category ID {request.CategoryId} does not exist.");

            product.UpdateDetails(request.Name, request.CategoryId, request.Price, request.StockQuantity, request.SupplierName);

            return MapToResponse(product);
        }

        public ProductResponse? UpdateStock(int id, int newQuantity)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return null;

            product.UpdateStock(newQuantity);

            return MapToResponse(product);
        }

        public bool Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return false;

            product.Deactivate();
            return true;
        }

        public IEnumerable<ProductResponse> GetLowStock(int threshold)
        {
            return _products.Where(p => p.StockQuantity <= threshold)
                            .Select(MapToResponse);
        }

        public StockValueReportResponse GetStockValueReport()
        {
            var categoryReports = _products
                .GroupBy(p => p.CategoryId)
                .Select(g => new CategoryStockValueDetail
                {
                    CategoryId = g.Key,
                    CategoryName = _categoryService.GetNameById(g.Key),
                    TotalItemsInStock = g.Sum(p => p.StockQuantity),
                    TotalValue = g.Sum(p => p.Price * p.StockQuantity)
                })
                .ToList();

            return new StockValueReportResponse
            {
                TotalSystemStockValue = categoryReports.Sum(c => c.TotalValue),
                CategoryBreakdown = categoryReports
            };
        }

        private ProductResponse MapToResponse(Product p) => new()
        {
            ProductId = p.ProductId,
            Name = p.Name,
            CategoryId = p.CategoryId,
            CategoryName = _categoryService.GetNameById(p.CategoryId),
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            IsAvailable = p.IsAvailable,
            SupplierName = p.SupplierName
        };
    }
}