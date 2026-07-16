namespace BookStoreApi.Models
{

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int AuthorId { get; set; } // Foreign Key Relation
        public int CategoryId { get; set; } // Foreign Key Relation
        public bool IsAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
}