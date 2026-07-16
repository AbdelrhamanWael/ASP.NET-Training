namespace Products___Categories_API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; } // Foreign Key link to Category
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}