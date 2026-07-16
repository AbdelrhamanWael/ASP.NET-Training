using System.ComponentModel.DataAnnotations;

namespace Products___Categories_API.DTOs
{
    public class UpdateProductRequest
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int StockQuantity { get; set; }

        public string SupplierName { get; set; } = string.Empty;
    }
}