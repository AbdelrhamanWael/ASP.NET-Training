using System;
using System.Linq;
using ProductCatalogSystem.Services;

namespace ProductCatalogSystem.UI
{
    public class ConsoleMenu
    {
        private ProductQueryService _queryService;

        public ConsoleMenu()
        {
            _queryService = new ProductQueryService();
        }

        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n====== Product Catalog LINQ System ======");
                Console.WriteLine("1. View Available Products");
                Console.WriteLine("2. Filter by Category");
                Console.WriteLine("3. Filter by Price Range");
                Console.WriteLine("4. Search by Name");
                Console.WriteLine("5. Sort by Price");
                Console.WriteLine("6. Group by Category");
                Console.WriteLine("7. Stock Value Reports");
                Console.WriteLine("8. Low Stock Products");
                Console.WriteLine("9. Supplier Report");
                Console.WriteLine("10. Pagination Demo");
                Console.WriteLine("11. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                try
                {
                    switch (input)
                    {
                        case "1": ViewAvailableProductsUI(); break;
                        case "2": FilterByCategoryUI(); break;
                        case "3": FilterByPriceRangeUI(); break;
                        case "4": SearchByNameUI(); break;
                        case "5": SortByPriceUI(); break;
                        case "6": GroupByCategoryUI(); break;
                        case "7": StockValueReportsUI(); break;
                        case "8": LowStockProductsUI(); break;
                        case "9": SupplierReportUI(); break;
                        case "10": PaginationDemoUI(); break;
                        case "11":
                            exit = true;
                            Console.WriteLine("Exiting System. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        private void ViewAvailableProductsUI()
        {
            var products = _queryService.GetAllProducts();
            Console.WriteLine("\n--- Available Products ---");
            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} | {p.Category} | {p.Price:C} | Stock: {p.StockQuantity}");
            }
        }

        private void FilterByCategoryUI()
        {
            Console.Write("Enter Category (e.g., Electronics, Furniture): ");
            string category = Console.ReadLine() ?? "";
            var products = _queryService.GetProductsByCategory(category);
            
            Console.WriteLine($"\n--- Products in '{category}' ---");
            if (!products.Any()) Console.WriteLine("No products found.");
            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} | {p.Price:C}");
            }
        }

        private void FilterByPriceRangeUI()
        {
            Console.Write("Enter Minimum Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal minPrice)) minPrice = 0;
            
            Console.Write("Enter Maximum Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal maxPrice)) maxPrice = decimal.MaxValue;

            if (minPrice > maxPrice)
            {
                Console.WriteLine("Error: Minimum price cannot be greater than maximum price.");
                return;
            }

            var products = _queryService.GetProductsByPriceRange(minPrice, maxPrice);
            
            Console.WriteLine($"\n--- Products between {minPrice:C} and {maxPrice:C} ---");
            if (!products.Any()) Console.WriteLine("No products found.");
            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} | {p.Price:C}");
            }
        }

        private void SearchByNameUI()
        {
            Console.Write("Enter Search Keyword: ");
            string keyword = Console.ReadLine() ?? "";
            var products = _queryService.SearchProductsByName(keyword);

            Console.WriteLine($"\n--- Search Results for '{keyword}' ---");
            if (!products.Any()) Console.WriteLine("No products found.");
            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} | {p.Category} | {p.Price:C}");
            }
        }

        private void SortByPriceUI()
        {
            Console.WriteLine("1. Sort Ascending");
            Console.WriteLine("2. Sort Descending");
            Console.Write("Choose sorting order: ");
            string choice = Console.ReadLine() ?? "";

            Console.WriteLine("\n--- Sorted Products ---");
            if (choice == "1")
            {
                var products = _queryService.GetProductsSortedByPriceAscending();
                foreach (var p in products) Console.WriteLine($"- {p.Name} | {p.Price:C}");
            }
            else if (choice == "2")
            {
                var products = _queryService.GetProductsSortedByPriceDescending();
                foreach (var p in products) Console.WriteLine($"- {p.Name} | {p.Price:C}");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }

        private void GroupByCategoryUI()
        {
            Console.WriteLine("\n--- Products Grouped By Category ---");
            var groups = _queryService.GroupProductsByCategory();
            foreach (var group in groups)
            {
                Console.WriteLine($"\nCategory: {group.Key} ({group.Count()} items)");
                foreach (var p in group)
                {
                    Console.WriteLine($"  - {p.Name} | {p.Price:C}");
                }
            }
        }

        private void StockValueReportsUI()
        {
            Console.WriteLine("\n--- Stock Value Reports ---");
            Console.WriteLine($"Total Overall Stock Value: {_queryService.CalculateTotalStockValue():C}");
            
            Console.WriteLine("\nValue per Category:");
            var valuePerCategory = _queryService.GetStockValuePerCategory();
            foreach (var item in valuePerCategory)
            {
                Console.WriteLine($"- {item.Key}: {item.Value:C}");
            }
        }

        private void LowStockProductsUI()
        {
            Console.WriteLine("\n--- Low Stock Products (Less than 10) ---");
            var products = _queryService.GetLowStockProducts();
            if (!products.Any()) Console.WriteLine("No low stock products.");
            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} | Stock: {p.StockQuantity}");
            }
        }

        private void SupplierReportUI()
        {
            Console.WriteLine("\n--- Supplier Reports ---");
            var reports = _queryService.GetSupplierReports();
            foreach (var report in reports)
            {
                Console.WriteLine($"Supplier: {report.SupplierName}");
                Console.WriteLine($"  Total Products: {report.ProductCount}");
                Console.WriteLine($"  Total Stock Value: {report.TotalStockValue:C}\n");
            }
        }

        private void PaginationDemoUI()
        {
            Console.Write("Enter Page Number: ");
            if (!int.TryParse(Console.ReadLine(), out int pageNumber)) pageNumber = 1;
            
            Console.Write("Enter Page Size: ");
            if (!int.TryParse(Console.ReadLine(), out int pageSize)) pageSize = 5;

            Console.WriteLine($"\n--- Pagination: Page {pageNumber}, Size {pageSize} ---");
            var products = _queryService.GetProductsByPage(pageNumber, pageSize);
            if (!products.Any()) Console.WriteLine("No products on this page.");
            foreach (var p in products)
            {
                Console.WriteLine($"- {p.Name} | {p.Price:C}");
            }
        }
    }
}
