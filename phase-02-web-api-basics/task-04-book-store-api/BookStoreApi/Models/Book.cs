namespace BookStoreApi.Models
{

    public class Book
    {
        public int BookId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string ISBN { get; private set; } = string.Empty;
        public int PublishedYear { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public int AuthorId { get; private set; } 
        public int CategoryId { get; private set; } 
        public bool IsAvailable { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Book() { }

        public Book(int bookId, string title, string isbn, int publishedYear, decimal price, int stockQuantity, int authorId, int categoryId)
        {
            BookId = bookId;
            Title = title;
            ISBN = isbn;
            PublishedYear = publishedYear;
            Price = price;
            StockQuantity = stockQuantity;
            AuthorId = authorId;
            CategoryId = categoryId;
            IsAvailable = stockQuantity > 0;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateDetails(string title, string isbn, int publishedYear, decimal price, int stockQuantity, int authorId, int categoryId)
        {
            Title = title;
            ISBN = isbn;
            PublishedYear = publishedYear;
            Price = price;
            StockQuantity = stockQuantity;
            AuthorId = authorId;
            CategoryId = categoryId;
            IsAvailable = stockQuantity > 0;
        }

        public void SoftDelete()
        {
            StockQuantity = 0;
            IsAvailable = false;
        }
    }
    
}