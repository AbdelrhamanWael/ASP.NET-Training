namespace ProductCatalogSystem.Models
{
    // This is the DTO (Data Transfer Object)
    public class ProductSummary
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string StockStatus { get; set; } // We will calculate this dynamically!
    }
}