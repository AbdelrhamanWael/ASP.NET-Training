namespace EFCoreDrillsApi.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        public ICollection<TrainingTrack> Tracks { get; set; } = new List<TrainingTrack>();
    }
}