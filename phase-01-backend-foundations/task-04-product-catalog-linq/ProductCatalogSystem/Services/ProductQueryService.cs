using System;
using System.Collections.Generic;
using System.Linq; // CRITICAL: You must include this to use LINQ!
using ProductCatalogSystem.Models;

namespace ProductCatalogSystem.Services
{
    public class ProductQueryService
    {
        private List<Product> _products;

        public ProductQueryService()
        {
            _products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Laptop Pro 14", Category = "Electronics", Price = 45000m, StockQuantity = 5, CreatedAt = new DateTime(2026, 1, 10), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 2, Name = "Wireless Mouse", Category = "Electronics", Price = 650m, StockQuantity = 50, CreatedAt = new DateTime(2026, 2, 1), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 3, Name = "Office Chair", Category = "Furniture", Price = 3500m, StockQuantity = 10, CreatedAt = new DateTime(2025, 12, 15), IsAvailable = true, SupplierName = "HomeSupplier" },
                new Product { ProductId = 4, Name = "Standing Desk", Category = "Furniture", Price = 8000m, StockQuantity = 3, CreatedAt = new DateTime(2026, 3, 5), IsAvailable = true, SupplierName = "HomeSupplier" },
                new Product { ProductId = 5, Name = "Notebook Pack", Category = "Stationery", Price = 120m, StockQuantity = 100, CreatedAt = new DateTime(2026, 1, 20), IsAvailable = true, SupplierName = "PaperSupplier" },
                new Product { ProductId = 6, Name = "Pen Set", Category = "Stationery", Price = 75m, StockQuantity = 200, CreatedAt = new DateTime(2026, 1, 25), IsAvailable = true, SupplierName = "PaperSupplier" },
                new Product { ProductId = 7, Name = "Gaming Keyboard", Category = "Electronics", Price = 2500m, StockQuantity = 7, CreatedAt = new DateTime(2026, 2, 12), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 8, Name = "Monitor 27 inch", Category = "Electronics", Price = 9000m, StockQuantity = 4, CreatedAt = new DateTime(2026, 2, 20), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 9, Name = "Desk Lamp", Category = "Furniture", Price = 650m, StockQuantity = 0, CreatedAt = new DateTime(2025, 11, 1), IsAvailable = false, SupplierName = "HomeSupplier" },
                new Product { ProductId = 10, Name = "Backpack", Category = "Accessories", Price = 1200m, StockQuantity = 15, CreatedAt = new DateTime(2026, 3, 10), IsAvailable = true, SupplierName = "BagSupplier" },
                new Product { ProductId = 11, Name = "USB-C Hub", Category = "Electronics", Price = 1250m, StockQuantity = 12, CreatedAt = new DateTime(2026, 4, 1), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 12, Name = "Whiteboard Markers", Category = "Stationery", Price = 95m, StockQuantity = 80, CreatedAt = new DateTime(2026, 2, 15), IsAvailable = true, SupplierName = "PaperSupplier" },
                new Product { ProductId = 13, Name = "Ergonomic Mouse Pad", Category = "Accessories", Price = 350m, StockQuantity = 25, CreatedAt = new DateTime(2026, 5, 1), IsAvailable = true, SupplierName = "BagSupplier" },
                new Product { ProductId = 14, Name = "Meeting Table", Category = "Furniture", Price = 12500m, StockQuantity = 2, CreatedAt = new DateTime(2025, 10, 20), IsAvailable = true, SupplierName = "HomeSupplier" },
                new Product { ProductId = 15, Name = "HD Webcam", Category = "Electronics", Price = 1800m, StockQuantity = 6, CreatedAt = new DateTime(2026, 4, 17), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 16, Name = "Printer Paper Box", Category = "Stationery", Price = 450m, StockQuantity = 30, CreatedAt = new DateTime(2026, 2, 28), IsAvailable = true, SupplierName = "PaperSupplier" },
                new Product { ProductId = 17, Name = "Laptop Stand", Category = "Accessories", Price = 950m, StockQuantity = 9, CreatedAt = new DateTime(2026, 3, 30), IsAvailable = true, SupplierName = "BagSupplier" },
                new Product { ProductId = 18, Name = "Network Cable 5m", Category = "Electronics", Price = 150m, StockQuantity = 60, CreatedAt = new DateTime(2026, 1, 5), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 19, Name = "Storage Cabinet", Category = "Furniture", Price = 6000m, StockQuantity = 1, CreatedAt = new DateTime(2025, 9, 10), IsAvailable = true, SupplierName = "HomeSupplier" },
                new Product { ProductId = 20, Name = "Sticky Notes", Category = "Stationery", Price = 60m, StockQuantity = 0, CreatedAt = new DateTime(2026, 5, 10), IsAvailable = false, SupplierName = "PaperSupplier" },
                new Product { ProductId = 21, Name = "Noise Cancelling Headset", Category = "Electronics", Price = 5200m, StockQuantity = 4, CreatedAt = new DateTime(2026, 3, 22), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 22, Name = "Desk Organizer", Category = "Accessories", Price = 300m, StockQuantity = 40, CreatedAt = new DateTime(2026, 6, 1), IsAvailable = true, SupplierName = "BagSupplier" },
                new Product { ProductId = 23, Name = "Projector", Category = "Electronics", Price = 22000m, StockQuantity = 2, CreatedAt = new DateTime(2026, 4, 28), IsAvailable = true, SupplierName = "TechSupplier" },
                new Product { ProductId = 24, Name = "Office Sofa", Category = "Furniture", Price = 15500m, StockQuantity = 1, CreatedAt = new DateTime(2025, 8, 18), IsAvailable = true, SupplierName = "HomeSupplier" },
                new Product { ProductId = 25, Name = "Calculator", Category = "Stationery", Price = 250m, StockQuantity = 35, CreatedAt = new DateTime(2026, 1, 12), IsAvailable = true, SupplierName = "PaperSupplier" }
            };
        }

        // Method to get all available products
        public List<Product> GetAllProducts()
        {
            return _products.Where(p => p.IsAvailable).ToList();
        }

        // Method to get products by category
        public List<Product> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase) && p.IsAvailable).ToList();
        }
        //Filter by Price Range
        public List<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _products.Where(p => p.Price >= minPrice && p.Price <= maxPrice && p.IsAvailable).ToList();
        }
        //Search by Product Name
        public List<Product> SearchProductsByName(string keyword)
        {
            return _products.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) && p.IsAvailable).ToList();
        }
        //Sort by Price Ascending
        public List<Product> GetProductsSortedByPriceAscending()
        {
            return _products.OrderBy(p => p.Price).ToList();
        }
        //Sort by Price Descending
        public List<Product> GetProductsSortedByPriceDescending()
        {
            return _products.OrderByDescending(p => p.Price).ToList();
        }
        // Group Products by Category
        public List<IGrouping<string, Product>> GroupProductsByCategory()
        {
            return _products.GroupBy(p => p.Category).ToList();
        }
        //Count Products per Category

        public Dictionary<string, int>  GetProductCountPerCategory()
        {
            return _products.GroupBy(p => p.Category)
                            .ToDictionary(g => g.Key, g => g.Count());
        }
        //Calculate Total Stock Value

        public decimal CalculateTotalStockValue()
        {
            return _products.Sum(p => p.Price * p.StockQuantity);
        }
        //Stock Value per Category

        public Dictionary<string, decimal> GetStockValuePerCategory()
        {
            return _products.GroupBy(p => p.Category)
                            .ToDictionary(g => g.Key, g => g.Sum(p => p.Price * p.StockQuantity));
        }
        //Top 5 Most Expensive Products

        public List<Product> GetTop5MostExpensiveProducts()
        {
            return _products.OrderByDescending(p => p.Price).Take(5).ToList();
        }
        //Low Stock Products

        public List<Product> GetLowStockProducts()
        {
            return _products.Where(p => p.StockQuantity < 10).ToList();
        }
        //Out of Stock Products
        public List<Product> GetOutOfStockProducts()
        {
            return _products.Where(p => p.StockQuantity == 0).ToList();
        }
        // Product Summary DTO Projection
        
        public List<ProductSummary> GetProductSummaries()
        {
            return _products.Select(p => new ProductSummary
            {
                // Map the existing data
                Name = p.Name,
                Price = p.Price,
                
                // Calculate the Stock Status on the fly based on the quantity
                StockStatus = p.StockQuantity == 0 ? "Out of Stock" : 
                             (p.StockQuantity < 5 ? "Low Stock" : "In Stock")
                             
            }).ToList(); // Convert the final result to a List
        }
        //Supplier Report

        public List<SupplierReport> GetSupplierReports()
        {
            return _products.GroupBy(p => p.SupplierName)
                            .Select(g => new SupplierReport
                            {
                                SupplierName = g.Key,
                                ProductCount = g.Count(),
                                TotalStockValue = g.Sum(p => p.Price * p.StockQuantity)
                            })
                            .ToList();
        }
        //Recently Added Products

        public List<Product> GetRecentlyAddedProducts()
        {
            return _products.OrderByDescending(p => p.CreatedAt).Take(5).ToList();
        }
        // Category Statistics
        public List<CategoryStats> GetCategoryStatistics()
        {
            // Acceptance Note: Handling empty groups safely. 
            // Using .Any() checks ensures we don't crash if a group somehow lacks data.
            return _products
                .GroupBy(p => p.Category)
                .Select(g => new CategoryStats
                {
                    CategoryName = g.Key,
                    Count = g.Count(),
                    AveragePrice = g.Any() ? g.Average(p => p.Price) : 0,
                    MaxPrice = g.Any() ? g.Max(p => p.Price) : 0,
                    MinPrice = g.Any() ? g.Min(p => p.Price) : 0,
                    TotalStockValue = g.Sum(p => p.Price * p.StockQuantity)
                }).ToList();
        }
        //Products Above Average Price
        public List<Product> GetProductsAboveAveragePrice()
        {
            if (!_products.Any()) return new List<Product>();

            // Step 1: Calculate the average
            decimal averagePrice = _products.Average(p => p.Price);

            // Step 2: Return products above that average
            return _products.Where(p => p.Price > averagePrice).ToList();
        }
        //Search + Filter Combined
        public List<Product> AdvancedSearch(string category, decimal? minPrice, decimal? maxPrice, bool? isAvailable)
        {
            // Start with the full list
            var query = _products.AsEnumerable();

            // Chain .Where() clauses dynamically based on what was provided
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            }

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= maxPrice.Value);
            }

            if (isAvailable.HasValue)
            {
                query = query.Where(p => p.IsAvailable == isAvailable.Value);
            }

            return query.ToList();
        }
        // LINQ QUERY 20 - Pagination Simulation
        public List<Product> GetProductsByPage(int pageNumber, int pageSize)
        {
            // Acceptance Note: Validate page number > 0
            if (pageNumber <= 0)
            {
                Console.WriteLine("Warning: Page number must be > 0. Defaulting to page 1.");
                pageNumber = 1; 
            }

            if (pageSize <= 0) 
            {
                pageSize = 5; // Default fallback
            }

            return _products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        


    }
}