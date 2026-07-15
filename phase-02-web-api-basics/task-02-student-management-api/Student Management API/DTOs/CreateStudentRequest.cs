using System.ComponentModel.DataAnnotations;

namespace StudentManagementApi.DTOs
{
    public class CreateStudentRequest
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty; // Required [cite: 745]

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = string.Empty; // Required [cite: 746]

        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; } = string.Empty; // Required [cite: 748]

        [Required(ErrorMessage = "Track Name is required.")]
        public string TrackName { get; set; } = string.Empty; // Required [cite: 747]

        public string? GitHubProfileUrl { get; set; }
        public string? LinkedInProfileUrl { get; set; }
    }
}