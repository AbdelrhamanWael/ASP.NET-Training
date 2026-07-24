namespace TrainingCenterApi.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; } // PK
        
        public int EnrollmentId { get; set; } // FK
        public Enrollment Enrollment { get; set; } = null!;

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string PaymentStatus { get; set; } = "Pending";
        public string? ReferenceNumber { get; set; }
        public string? Notes { get; set; }
    }
}