namespace Products___Categories_API.Models
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public int CategoryId { get; private set; } // Foreign Key link to Category
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public bool IsAvailable { get; private set; }
        public string SupplierName { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        private Product() { }

        public Product(int productId, string name, int categoryId, decimal price, int stockQuantity, string supplierName)
        {
            ProductId = productId;
            Name = name;
            CategoryId = categoryId;
            Price = price;
            StockQuantity = stockQuantity;
            IsAvailable = stockQuantity > 0;
            SupplierName = supplierName;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateDetails(string name, int categoryId, decimal price, int stockQuantity, string supplierName)
        {
            Name = name;
            CategoryId = categoryId;
            Price = price;
            StockQuantity = stockQuantity;
            IsAvailable = stockQuantity > 0;
            SupplierName = supplierName;
        }

        public void UpdateStock(int stockQuantity)
        {
            StockQuantity = stockQuantity;
            IsAvailable = stockQuantity > 0;
        }
        
        public void Deactivate()
        {
            StockQuantity = 0;
            IsAvailable = false;
        }
    }
}