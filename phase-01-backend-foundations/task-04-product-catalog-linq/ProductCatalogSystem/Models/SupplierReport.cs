namespace ProductCatalogSystem.Models
{
    // This is the DTO (Data Transfer Object)
    public class SupplierReport
    {
        public string SupplierName { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalStockValue { get; set; }

       
    }
}