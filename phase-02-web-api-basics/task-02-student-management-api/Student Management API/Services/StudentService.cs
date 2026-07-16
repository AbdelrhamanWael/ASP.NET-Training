using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Student_Management_API.Data;
using Student_Management_API.Models;
using StudentManagementApi.DTOs;

namespace StudentManagementApi.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        private static StudentResponse MapToResponse(Student s) => new()
        {
            StudentId = s.StudentId,
            FullName = s.FullName,
            Email = s.Email,
            PhoneNumber = s.PhoneNumber,
            TrackName = s.TrackName,
            EnrollmentDate = s.EnrollmentDate,
            IsActive = s.IsActive,
            GitHubProfileUrl = s.GitHubProfileUrl,
            LinkedInProfileUrl = s.LinkedInProfileUrl
        };

        public async Task<StudentResponse> CreateAsync(CreateStudentRequest request)
        {
            var student = new Student(
                request.FullName,
                request.Email,
                request.PhoneNumber,
                request.TrackName,
                request.GitHubProfileUrl,
                request.LinkedInProfileUrl
            );

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return MapToResponse(student);
        }

        public async Task<IEnumerable<StudentResponse>> GetAllAsync(string? search, string? track, bool? isActive, int pageNumber, int pageSize)
        {
            var query = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.FullName.Contains(search) ||
                                         s.Email.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(track))
            {
                query = query.Where(s => s.TrackName == track);
            }

            if (isActive.HasValue)
            {
                query = query.Where(s => s.IsActive == isActive.Value);
            }

            var students = await query.Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();

            return students.Select(MapToResponse);
        }

        public async Task<StudentResponse?> GetByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            return student == null ? null : MapToResponse(student);
        }

        public async Task<StudentResponse?> UpdateAsync(int id, UpdateStudentRequest request)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            student.UpdateDetails(
                request.FullName,
                request.Email,
                request.PhoneNumber,
                request.TrackName,
                request.GitHubProfileUrl,
                request.LinkedInProfileUrl
            );

            await _context.SaveChangesAsync();
            return MapToResponse(student);
        }

        public async Task<StudentResponse?> UpdateStatusAsync(int id, UpdateStudentStatusRequest request)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }

            student.SetStatus(request.IsActive);
            await _context.SaveChangesAsync();
            return MapToResponse(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<StudentStatsResponse> GetStatsAsync()
        {
            var totalStudents = await _context.Students.CountAsync();
            var activeStudents = await _context.Students.CountAsync(s => s.IsActive);
            var inactiveStudents = await _context.Students.CountAsync(s => !s.IsActive);
            var countByTrack = await _context.Students.GroupBy(s => s.TrackName)
                                                      .Select(g => new { TrackName = g.Key, Count = g.Count() })
                                                      .ToDictionaryAsync(g => g.TrackName, g => g.Count);

            return new StudentStatsResponse
            {
                TotalStudents = totalStudents,
                ActiveStudents = activeStudents,
                InactiveStudents = inactiveStudents,
                CountByTrack = countByTrack
            };
        }
    }
}
