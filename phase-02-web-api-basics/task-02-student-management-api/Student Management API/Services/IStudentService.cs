using System.Collections.Generic;
using System.Threading.Tasks;
using StudentManagementApi.DTOs;

namespace StudentManagementApi.Services
{
    public interface IStudentService
    {
        Task<StudentResponse> CreateAsync(CreateStudentRequest request);
        Task<IEnumerable<StudentResponse>> GetAllAsync(string? search, string? track, bool? isActive, int pageNumber, int pageSize);
        Task<StudentResponse?> GetByIdAsync(int id);

        Task<StudentResponse?> UpdateAsync(int id, UpdateStudentRequest request);
        Task<StudentResponse?> UpdateStatusAsync(int id, UpdateStudentStatusRequest request);
        Task<bool> DeleteAsync(int id);
        Task<StudentStatsResponse> GetStatsAsync();
    }
}