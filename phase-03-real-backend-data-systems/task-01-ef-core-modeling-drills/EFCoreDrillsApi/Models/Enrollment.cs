
namespace EFCoreDrillsApi.Models
{
    public class Enrollment
    {

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TrainingTrackId { get; set; }
        public string   Status { get; set; } = string.Empty;
        public DateTime  EnrollmentDate { get; set; }   
        public int FinalGrade { get; set; } 
        public Student Student { get; set; } = null!;
        public TrainingTrack TrainingTrack { get; set; } = null!;

        public PaymentSummary? PaymentSummary { get; set; }


    }
}