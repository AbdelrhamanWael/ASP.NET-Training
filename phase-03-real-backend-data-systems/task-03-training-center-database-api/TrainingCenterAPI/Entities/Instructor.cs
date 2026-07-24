namespace TrainingCenterApi.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; } // PK
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property: 1:M with TrainingTrack
        public ICollection<TrainingTrack> TrainingTracks { get; set; } = new List<TrainingTrack>();
    }
}