using EFCoreDrillsApi.Models;

namespace EFCoreDrillsApi 
{
    public class PaymentSummary
    {
        public int Id { get; set; }
        
        // Unique Foreign Key for the 1:1 relationship
        public int EnrollmentId { get; set; }

        // Decimal fields for money values
        public decimal TotalRequired { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemainingAmount { get; set; }
        
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        
        public Enrollment Enrollment { get; set; } = null!;
    }
}