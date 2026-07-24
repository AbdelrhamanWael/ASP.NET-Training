using Microsoft.EntityFrameworkCore;
using TrainingCenterApi.DTOs;
using TrainingCenterApi.Entities;
using TrainingCenterApi.Common;
using TrainingCenterAPI.Data;

namespace TrainingCenterApi.Services
{
    public class StudentService : IStudentService
    {
        public readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginationResult<StudentListItemResponse>> GetStudentsAsync(int pageNumber, int pageSize, string? search, bool? isActive)
        {
            var query = _context.Students.Where(s => !s.IsDeleted);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(s =>s.FullName.Contains(search) || 
                                        s.Email.Contains(search) || 
                                        (s.PhoneNumber != null && s.PhoneNumber.Contains(search)));
            }
            if (isActive.HasValue)
            {
                query = query.Where(s=>s.IsActive == isActive.Value);
            }
            var totalCount = await query.CountAsync();
            var skip = (pageNumber - 1) * pageSize;

            var items = await query
                .Skip(skip)
                .Take(pageSize)
                .Select(s => new StudentListItemResponse
                {
                    StudentId = s.StudentId,
                    FullName = s.FullName,
                    Email = s.Email,
                    IsActive = s.IsActive
                    
                })
                .ToListAsync();
                

            return new PaginationResult<StudentListItemResponse>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            
        }
public async Task<StudentDetailsResponse?> GetStudentByIdAsync(int id)
        {
            return await _context.Students
                .Where(s => s.StudentId == id && !s.IsDeleted)
                .Select(s => new StudentDetailsResponse
                {
                    StudentId = s.StudentId,
                    FullName = s.FullName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    IsActive = s.IsActive,
                    ActiveEnrollmentsCount = s.Enrollments.Count(e => e.Status == "Active")
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool IsSuccess, string ErrorMessage, StudentDetailsResponse? Data)> CreateStudentAsync(CreateStudentRequest request)
        {
            // Enforce Business Rule: Email must be unique
            if (await _context.Students.AnyAsync(s => s.Email == request.Email))
            {
                return (false, "A student with this email already exists.", null);
            }

            var student = new Student
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                IsActive = true
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            var response = new StudentDetailsResponse
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                IsActive = student.IsActive,
                ActiveEnrollmentsCount = 0
            };

            return (true, string.Empty, response);
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> UpdateStudentAsync(int id, UpdateStudentRequest request)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id && !s.IsDeleted);
            
            if (student == null) 
            {
                return (false, "Student not found.");
            }

            student.FullName = request.FullName;
            student.PhoneNumber = request.PhoneNumber;
            student.IsActive = request.IsActive;
            
            await _context.SaveChangesAsync();
            return (true, string.Empty);
        }

        public async Task<(bool IsSuccess, string ErrorMessage)> DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == id && !s.IsDeleted);
            
            if (student == null) 
            {
                return (false, "Student not found.");
            }

            // Enforce Business Rule: Soft delete instead of hard delete
            student.IsDeleted = true;
            student.DeletedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return (true, string.Empty);
        }
    }



}
