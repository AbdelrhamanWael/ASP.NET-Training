

namespace TrainingCenterApi.DTOs
{

    public class CreateStudentRequest
    {
        public string  FullName { get; set; } = string.Empty;   
        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }
    }
    public class UpdateStudentRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }

    public class StudentListItemResponse
    {
        public int StudentId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class StudentDetailsResponse : StudentListItemResponse
    {
        public string? PhoneNumber { get; set; }
        public int ActiveEnrollmentsCount { get; set; }
    }
}