using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreApi.DTOs;
using BookStoreApi.Models;

namespace BookStoreApi.Services
{
    
    public class AuthorService : IAuthorService
    {
        private static readonly List<Author> _authors = new()
        {
            new Author(1, "Robert C. Martin", "USA", new DateTime(1952, 12, 5)),
            new Author(2, "Andrew Hunt", "UK", new DateTime(1964, 10, 2))
        };
        private static int _nextId = 3;
        private static AuthorResponse MapToResponse(Author a) => new()
        {
            AuthorId = a.AuthorId,
            FullName = a.FullName,
            Country = a.Country,
            BirthDate = a.BirthDate
        };

        public AuthorResponse Create(CreateAuthorRequest request)
        {
            if (_authors.Any(a => a.FullName.Equals(request.FullName, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("An author with this exact full name already exists.");
            var author = new Author(_nextId++, request.FullName, request.Country, request.BirthDate);
            _authors.Add(author);
            return MapToResponse(author);
        }

        public IEnumerable<AuthorResponse> GetAll() => _authors.Select(MapToResponse);

        public bool Exists(int authorId) => _authors.Any(a => a.AuthorId == authorId);

        public string GetNameById(int authorId) => _authors.FirstOrDefault(a => a.AuthorId == authorId)?.FullName ?? string.Empty;

    }

}