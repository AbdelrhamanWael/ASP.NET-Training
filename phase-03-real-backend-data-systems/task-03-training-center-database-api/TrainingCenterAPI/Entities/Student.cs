namespace TrainingCenterApi.Entities
{
    public class Student
    {
        public int StudentId { get; set; } // PK
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // Navigation Property: 1:M with Enrollment
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}