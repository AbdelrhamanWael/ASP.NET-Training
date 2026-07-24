
using TrainingCenterApi.DTOs;
using TrainingCenterApi.Entities;
using TrainingCenterApi.Common;

namespace TrainingCenterApi.Services
{
    public interface IStudentService
    {
        Task<PaginationResult<StudentListItemResponse>> GetStudentsAsync(int pageNumber, int pageSize, string? search, bool? isActive);
        Task<StudentDetailsResponse?> GetStudentByIdAsync(int id);
        Task<(bool IsSuccess, string ErrorMessage, StudentDetailsResponse? Data)> CreateStudentAsync(CreateStudentRequest request);
        Task<(bool IsSuccess, string ErrorMessage)> UpdateStudentAsync(int id, UpdateStudentRequest request);
        Task<(bool IsSuccess, string ErrorMessage)> DeleteStudentAsync(int id);
    }
}