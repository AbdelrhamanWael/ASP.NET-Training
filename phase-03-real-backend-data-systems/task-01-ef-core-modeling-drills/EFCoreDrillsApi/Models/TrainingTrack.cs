namespace EFCoreDrillsApi.Models
{
    public class TrainingTrack : IAuditable
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = null!;
        // Add this inside the TrainingTrack class
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}