using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Student_Management_API.Models
{
    public class Student
    {
        public int StudentId { get; set; } 
        public string FullName { get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty; 
        public string PhoneNumber { get; set; } = string.Empty; 
        public string TrackName { get; set; } = string.Empty; 
        public DateTime EnrollmentDate { get; set; } 
        public bool IsActive { get; set; } 
        public string? GitHubProfileUrl { get; set; } 
        public string? LinkedInProfileUrl { get; set; }
    }
}