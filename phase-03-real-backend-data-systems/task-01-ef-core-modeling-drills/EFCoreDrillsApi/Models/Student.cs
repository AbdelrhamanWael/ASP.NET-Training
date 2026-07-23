namespace EFCoreDrillsApi.Models
{
    public class Student : IAuditable
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        
        public DateTime? UpdatedAt { get; set; }
        
        public StudentProfile? Profile { get; set; } = null;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();


        public bool IsDeleted { get; set; } = false;

        public DateTime? DeletedAt { get; set; } = null;
    }
}