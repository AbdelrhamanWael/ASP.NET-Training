namespace EFCoreDrillsApi.Models
{
    public class StudentProfile
    {
        
        public int StudentId { get; set; }

        public string NationalId { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
        
        public DateTime DateOfBirth { get; set; }
        public string EmergencyPhone { get; set; } = string.Empty;

        public Student? Student { get; set; } = null;
    }

}