using System;
using System.Collections.Generic;

namespace BookStoreApi.DTOs
{
    public class BookResponse
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int PublishedYear { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = string.Empty; // Relational lookup
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty; // Relational lookup
        public bool IsAvailable { get; set; }
    }

    public class BookSummaryReportResponse
    {
        public int TotalBooksInSystem { get; set; }
        public int TotalUniqueTitles { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public Dictionary<string, int> BooksPerCategory { get; set; } = new();
    }
}