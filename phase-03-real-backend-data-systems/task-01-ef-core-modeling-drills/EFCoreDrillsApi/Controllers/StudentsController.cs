
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDrillsApi.Data;
using EFCoreDrillsApi.DTOs;


namespace EFCoreDrillsApi.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents([FromQuery] bool includeDeleted = false)
        {
            var query = _context.Students.AsQueryable();

            // Ignore the global query filter if the admin wants to see deleted records
            if (includeDeleted)
            {
                query = query.IgnoreQueryFilters();
            }

            var students = await query.Select(s => new 
            {
                s.Id,
                s.FullName,
                s.IsDeleted,
                s.DeletedAt
            }).ToListAsync();

            return Ok(students);
        }

        // DELETE endpoint must mark deleted, not remove row
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound("Student not found.");

            // Soft delete logic
            student.IsDeleted = true;
            student.DeletedAt = DateTime.UtcNow;

            // Do NOT call _context.Students.Remove(student);
            
            await _context.SaveChangesAsync();

            return Ok("Student successfully deactivated.");
        }
        [HttpGet("{id}/enrollments")]
        public async Task<IActionResult> GetStudentEnrollments(int id)
        {
            var student = await _context.Students
                .Include(s => s.Enrollments) // Include the join table
                    .ThenInclude(e => e.TrainingTrack) // Include the track from the join table
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null) return NotFound("Student not found.");

            // Project to DTO shape to prevent JSON cycle loops
            var response = new
            {
                student.Id,
                student.FullName,
                Enrollments = student.Enrollments.Select(e => new
                {
                    e.Id,
                    e.Status,
                    e.EnrollmentDate,
                    TrackTitle = e.TrainingTrack.Title
                })
            };

            return Ok(response);
        }

        [HttpGet("list")]

        public async Task<IActionResult> GetStudentList()
        {
            var students = await _context.Students
                .Where(s => !s.IsDeleted)
                .Select(s => new StudentListItemDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email
                })
                .ToListAsync();

            return Ok(students);

        }
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedStudents([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            // 1. Validation Rules
            if (pageNumber <= 0)
            {
                return BadRequest("Page number must be greater than 0.");
            }
            if (pageSize < 1 || pageSize > 50)
            {
                return BadRequest("Page size must be between 1 and 50.");
            }

            var query = _context.Students.Where(s => !s.IsDeleted);

            // 2. Count Total Records (before applying Skip/Take)
            var totalCount = await query.CountAsync();

            // 3. Calculate Skip
            var skip = (pageNumber - 1) * pageSize;

            // 4. Fetch Paginated Data
            var items = await query
                .Skip(skip)
                .Take(pageSize)
                .Select(s => new StudentListItemDto
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email
                })
                .ToListAsync();

            // 5. Assemble Result
            var result = new PaginationResult<StudentListItemDto>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Ok(result);
        }
            
    }


}