using System.Collections.Generic;
using BookStoreApi.DTOs;

namespace BookStoreApi.Services
{
    public interface IBookService
    {
        BookResponse Create(CreateBookRequest request);
        IEnumerable<BookResponse> GetAll(string? search, int? categoryId, int? authorId, bool? isAvailable, int pageNumber, int pageSize);
        BookResponse? GetById(int id);
        BookResponse? Update(int id, UpdateBookRequest request);
        bool Delete(int id);
        BookSummaryReportResponse GetSummaryReport();
        bool HasBooksByAuthor(int authorId);
    }
}