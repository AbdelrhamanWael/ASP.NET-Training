using System;

namespace BookStoreApi.Models
{
    public class Author
    {
        public int AuthorId { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public string Country { get; private set; } = string.Empty;
        public DateTime? BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Author() { }

        public Author(int authorId, string fullName, string country, DateTime? birthDate)
        {
            AuthorId = authorId;
            FullName = fullName;
            Country = country;
            BirthDate = birthDate;
            CreatedAt = DateTime.UtcNow;
        }
    }
}