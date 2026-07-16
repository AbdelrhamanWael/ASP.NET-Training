using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreApi.DTOs;
using BookStoreApi.Models;

namespace BookStoreApi.Services
{
    public class BookService : IBookService
    {
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private static readonly List<Book> _books = new();
        private static int _nextId = 1;

        public BookService(IAuthorService authorService, ICategoryService categoryService)
        {
            _authorService = authorService;
            _categoryService = categoryService;

            if (!_books.Any())
            {
                _books.Add(new Book { BookId = _nextId++, Title = "Clean Code", ISBN = "978-0132350884", PublishedYear = 2008, Price = 42.99m, StockQuantity = 15, AuthorId = 1, CategoryId = 1, IsAvailable = true, CreatedAt = DateTime.UtcNow });
                _books.Add(new Book {  BookId = _nextId++, Title = "The Pragmatic Programmer", ISBN = "978-0135957059", PublishedYear = 2019, Price = 48.50m, StockQuantity = 7, AuthorId = 2, CategoryId = 1, IsAvailable = true, CreatedAt = DateTime.UtcNow });
            }
        }

        public BookResponse Create(CreateBookRequest request)
        {
            // Business Rules Validations
            if (!_authorService.Exists(request.AuthorId)) throw new ArgumentException("The specified AuthorId does not exist.");
            if (!_categoryService.Exists(request.CategoryId)) throw new ArgumentException("The specified CategoryId does not exist or is inactive.");
            if (_books.Any(b => b.ISBN.Equals(request.ISBN, StringComparison.OrdinalIgnoreCase))) throw new ArgumentException("ISBN must be unique across the library catalog.");

            var book = new Book
            {
                BookId = _nextId++,
                Title = request.Title,
                ISBN = request.ISBN,
                PublishedYear = request.PublishedYear,
                Price = request.Price,
                StockQuantity = request.StockQuantity,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                IsAvailable = request.StockQuantity > 0,
                CreatedAt = DateTime.UtcNow
            };
            _books.Add(book);
            return MapToResponse(book);
        }

        public IEnumerable<BookResponse> GetAll(string? search, int? categoryId, int? authorId, bool? isAvailable, int pageNumber, int pageSize)
        {
            var query = _books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(b => b.Title.Contains(search, StringComparison.OrdinalIgnoreCase) || b.ISBN.Equals(search, StringComparison.OrdinalIgnoreCase));

            if (categoryId.HasValue) query = query.Where(b => b.CategoryId == categoryId.Value);
            if (authorId.HasValue) query = query.Where(b => b.AuthorId == authorId.Value);
            if (isAvailable.HasValue) query = query.Where(b => b.IsAvailable == isAvailable.Value);

            return query.Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(MapToResponse)
                        .ToList();
        }

        public BookResponse? GetById(int id)
        {
            var book = _books.FirstOrDefault(b => b.BookId == id);
            return book == null ? null : MapToResponse(book);
        }

        public BookResponse? Update(int id, UpdateBookRequest request)
        {
            var book = _books.FirstOrDefault(b => b.BookId == id);
            if (book == null) return null;

            if (!_authorService.Exists(request.AuthorId)) throw new ArgumentException("The specified AuthorId does not exist.");
            if (!_categoryService.Exists(request.CategoryId)) throw new ArgumentException("The specified CategoryId does not exist.");
            if (_books.Any(b => b.ISBN.Equals(request.ISBN, StringComparison.OrdinalIgnoreCase) && b.BookId != id)) throw new ArgumentException("Another book already uses this ISBN.");

            book.Title = request.Title;
            book.ISBN = request.ISBN;
            book.PublishedYear = request.PublishedYear;
            book.Price = request.Price;
            book.StockQuantity = request.StockQuantity;
            book.AuthorId = request.AuthorId;
            book.CategoryId = request.CategoryId;
            book.IsAvailable = request.StockQuantity > 0;

            return MapToResponse(book);
        }

        public bool Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.BookId == id);
            if (book == null) return false;

            // Soft-delete pattern matching business specs
            book.StockQuantity = 0;
            book.IsAvailable = false;
            return true;
        }

        public bool HasBooksByAuthor(int authorId) => _books.Any(b => b.AuthorId == authorId && b.IsAvailable);

        public BookSummaryReportResponse GetSummaryReport()
        {
            return new BookSummaryReportResponse
            {
                TotalBooksInSystem = _books.Sum(b => b.StockQuantity),
                TotalUniqueTitles = _books.Count,
                TotalInventoryValue = _books.Sum(b => b.Price * b.StockQuantity),
                BooksPerCategory = _books.GroupBy(b => b.CategoryId)
                                        .ToDictionary(g => _categoryService.GetNameById(g.Key), g => g.Count())
            };
        }

        private BookResponse MapToResponse(Book b) => new()
        {
            BookId = b.BookId,
            Title = b.Title,
            ISBN = b.ISBN,
            PublishedYear = b.PublishedYear,
            Price = b.Price,
            StockQuantity = b.StockQuantity,
            AuthorId = b.AuthorId,
            AuthorName = _authorService.GetNameById(b.AuthorId),
            CategoryId = b.CategoryId,
            CategoryName = _categoryService.GetNameById(b.CategoryId),
            IsAvailable = b.IsAvailable
        };
    }
}