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
            
            new Product { ProductId = 1, Name = "Smartphone", CategoryId = 1, Price = 699.99m, StockQuantity = 12, IsAvailable = true, SupplierName = "ElectroMax", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 2, Name = "Laptop Pro", CategoryId = 1, Price = 1299.50m, StockQuantity = 8, IsAvailable = true, SupplierName = "ElectroMax", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 3, Name = "Wireless Headphones", CategoryId = 1, Price = 149.99m, StockQuantity = 25, IsAvailable = true, SupplierName = "SoundSonic", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 4, Name = "Smartwatch", CategoryId = 1, Price = 199.00m, StockQuantity = 3, IsAvailable = true, SupplierName = "WearTech", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 5, Name = "Bluetooth Speaker", CategoryId = 1, Price = 79.99m, StockQuantity = 0, IsAvailable = false, SupplierName = "SoundSonic", CreatedAt = DateTime.UtcNow },

            
            new Product { ProductId = 6, Name = "Office Desk", CategoryId = 2, Price = 249.99m, StockQuantity = 5, IsAvailable = true, SupplierName = "WoodCraft", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 7, Name = "Ergonomic Chair", CategoryId = 2, Price = 189.50m, StockQuantity = 10, IsAvailable = true, SupplierName = "ComfortSeat", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 8, Name = "Bookshelf", CategoryId = 2, Price = 120.00m, StockQuantity = 2, IsAvailable = true, SupplierName = "WoodCraft", CreatedAt = DateTime.UtcNow },

            
            new Product { ProductId = 9, Name = "Notebook A5", CategoryId = 3, Price = 4.50m, StockQuantity = 150, IsAvailable = true, SupplierName = "PaperCo", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 10, Name = "Gel Pens Pack", CategoryId = 3, Price = 8.99m, StockQuantity = 85, IsAvailable = true, SupplierName = "InkLine", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 11, Name = "Desk Organizer", CategoryId = 3, Price = 19.99m, StockQuantity = 14, IsAvailable = true, SupplierName = "PaperCo", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 12, Name = "Stapler", CategoryId = 3, Price = 6.50m, StockQuantity = 4, IsAvailable = true, SupplierName = "OfficeSupplies", CreatedAt = DateTime.UtcNow },

            
            new Product { ProductId = 13, Name = "Leather Wallet", CategoryId = 4, Price = 45.00m, StockQuantity = 20, IsAvailable = true, SupplierName = "FashionHub", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 14, Name = "Backpack", CategoryId = 4, Price = 59.99m, StockQuantity = 15, IsAvailable = true, SupplierName = "TravelStore", CreatedAt = DateTime.UtcNow },
            new Product { ProductId = 15, Name = "Sunglasses", CategoryId = 4, Price = 120.00m, StockQuantity = 1, IsAvailable = true, SupplierName = "FashionHub", CreatedAt = DateTime.UtcNow }
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

            var product = new Product
            {
                ProductId = _nextId++,
                Name = request.Name,
                CategoryId = request.CategoryId,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                IsAvailable = request.StockQuantity > 0,
                SupplierName = request.SupplierName,
                CreatedAt = DateTime.UtcNow
            };
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

            product.Name = request.Name;
            product.CategoryId = request.CategoryId;
            product.Price = request.Price;
            product.StockQuantity = request.StockQuantity;
            product.IsAvailable = request.StockQuantity > 0;
            product.SupplierName = request.SupplierName;

            return MapToResponse(product);
        }

        public ProductResponse? UpdateStock(int id, int newQuantity)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return null;

            product.StockQuantity = newQuantity;
            product.IsAvailable = newQuantity > 0;

            return MapToResponse(product);
        }

        public bool Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) return false;

            product.StockQuantity = 0;
            product.IsAvailable = false;
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