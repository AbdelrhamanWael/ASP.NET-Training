namespace TrainingCenterApi.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; } // PK
        
        public int StudentId { get; set; } // FK
        public Student Student { get; set; } = null!;
        
        public int TrainingTrackId { get; set; } // FK
        public TrainingTrack TrainingTrack { get; set; } = null!;

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public decimal ProgressPercentage { get; set; }
        public decimal? FinalResult { get; set; } // Optional
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation Property: 1:M with Payment
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}