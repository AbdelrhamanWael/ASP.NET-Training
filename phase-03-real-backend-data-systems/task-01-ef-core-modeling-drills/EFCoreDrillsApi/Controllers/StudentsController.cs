
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDrillsApi.Data;


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
    }

}