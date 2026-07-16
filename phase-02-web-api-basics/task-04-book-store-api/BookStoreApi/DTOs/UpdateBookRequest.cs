using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class UpdateBookRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "ISBN is required.")]
        public string ISBN { get; set; } = string.Empty;

        [Range(1000, 2100, ErrorMessage = "Please provide a valid publication year.")]
        public int PublishedYear { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int StockQuantity { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}