using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Student_Management_API.Models
{
    public class Student
    {
        public int StudentId { get; private set; } 
        public string FullName { get; private set; } = string.Empty; 
        public string Email { get; private set; } = string.Empty; 
        public string PhoneNumber { get; private set; } = string.Empty; 
        public string TrackName { get; private set; } = string.Empty; 
        public DateTime EnrollmentDate { get; private set; } 
        public bool IsActive { get; private set; } 
        public string? GitHubProfileUrl { get; private set; } 
        public string? LinkedInProfileUrl { get; private set; }

        private Student() { }

        public Student(string fullName, string email, string phoneNumber, string trackName, string? gitHubProfileUrl, string? linkedInProfileUrl)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            TrackName = trackName;
            GitHubProfileUrl = gitHubProfileUrl;
            LinkedInProfileUrl = linkedInProfileUrl;
            EnrollmentDate = DateTime.UtcNow;
            IsActive = true;
        }

        public void UpdateDetails(string fullName, string email, string phoneNumber, string trackName, string? gitHubProfileUrl, string? linkedInProfileUrl)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            TrackName = trackName;
            GitHubProfileUrl = gitHubProfileUrl;
            LinkedInProfileUrl = linkedInProfileUrl;
        }

        public void SetStatus(bool isActive)
        {
            IsActive = isActive;
        }
    }
}