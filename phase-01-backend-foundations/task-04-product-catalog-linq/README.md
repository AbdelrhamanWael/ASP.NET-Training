# Product Catalog LINQ System

A C# console application designed to demonstrate the power of Language Integrated Query (LINQ). It implements a comprehensive set of operations over an in-memory collection of products, handling filtering, ordering, grouping, aggregations, and data projections.

## Features

- **View Available Products**: Lists all products currently marked as available.
- **Filter by Category & Price Range**: Search products by specific categories (Electronics, Furniture, Stationery, etc.) and restrict results within a custom price range.
- **Search by Name**: Case-insensitive keyword searching for products.
- **Sort by Price**: Order products in either ascending or descending order by price.
- **Group by Category**: Groups all products under their respective categories.
- **Stock Value Reports**: Calculates the total monetary value of all stock, overall and per category.
- **Low Stock Products**: Identifies products that have dangerously low stock levels.
- **Supplier Report**: Generates aggregate reports showing total product count and stock value grouped by supplier.
- **Pagination Demo**: Demonstrates how to paginate results using LINQ `.Skip()` and `.Take()`.

## Project Structure

- **Models/**: Contains entities and DTOs used throughout the application (`Product`, `ProductSummary`, `SupplierReport`, `CategoryStats`).
- **Services/**: 
  - `ProductQueryService.cs`: Contains the core logic and all 15+ LINQ queries used for searching, filtering, aggregating, and paginating data.
- **UI/**: 
  - `ConsoleMenu.cs`: A fully interactive text-based UI menu to access all product queries.
- **Program.cs**: The main entry point that spins up the console menu loop.

## How to Run

1. Open your terminal.
2. Navigate to the project directory:
   ```powershell
   cd phase-01-backend-foundations\task-04-product-catalog-linq\ProductCatalogSystem
   ```
3. Run the application:
   ```powershell
   dotnet run
   ```
