namespace TrainingCenterApi.Entities
{
    public class TrainingTrack
    {
        public int TrainingTrackId { get; set; } // PK
        public string Title { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Level { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Open";
        
        public int InstructorId { get; set; } // FK
        public Instructor Instructor { get; set; } = null!; // Navigation

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;

        // Navigation Property: 1:M with Enrollment
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}