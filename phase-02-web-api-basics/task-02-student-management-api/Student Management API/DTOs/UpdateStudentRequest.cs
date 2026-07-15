using System.ComponentModel.DataAnnotations;

namespace StudentManagementApi.DTOs
{
    public class UpdateStudentRequest
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Track Name is required.")]
        public string TrackName { get; set; } = string.Empty;

        public string? GitHubProfileUrl { get; set; }
        public string? LinkedInProfileUrl { get; set; }
    }
}