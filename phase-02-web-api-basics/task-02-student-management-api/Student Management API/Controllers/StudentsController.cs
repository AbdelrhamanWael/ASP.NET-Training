using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentManagementApi.DTOs;
using StudentManagementApi.Services;

namespace Student_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? search, string? track, bool? isActive, int pageNumber = 1, int pageSize = 10)
        {
            var results = await _studentService.GetAllAsync(search, track, isActive, pageNumber, pageSize);
            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest request)
        {
            var student = await _studentService.CreateAsync(request);
            return CreatedAtAction(nameof(GetById), new { id = student.StudentId }, student);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateStudentRequest request)
        {
            var response = await _studentService.UpdateAsync(id, request);
            if (response == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }
            return Ok(response);
        }

        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateStudentStatusRequest request)
        {
            var response = await _studentService.UpdateStatusAsync(id, request);
            if (response == null)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }
            return Ok(new { message = "Status updated successfully.", student = response });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _studentService.DeleteAsync(id);
            if (!success)
            {
                return NotFound(new { message = $"Student with ID {id} not found." });
            }
            return NoContent();
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetStats()
        {
            var stats = await _studentService.GetStatsAsync();
            return Ok(stats);
        }
    }
}