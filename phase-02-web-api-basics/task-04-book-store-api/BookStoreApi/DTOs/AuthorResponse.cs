using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApi.DTOs
{
    public class CreateAuthorRequest
    {
        [Required(ErrorMessage = "Author full name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }

    public class AuthorResponse
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
    }
}