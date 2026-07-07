namespace ProductCatalogSystem.Models
{
    public class CategoryStats
    {
        public string CategoryName { get; set; }
        public int Count { get; set; }
        public decimal AveragePrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }
        public decimal TotalStockValue { get; set; }
    }
}