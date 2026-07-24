using Microsoft.AspNetCore.Mvc;
using TrainingCenterApi.DTOs;
using TrainingCenterApi.Services;

namespace TrainingCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult>GetStudents([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, [FromQuery] bool? isActive = null)
        {
            if(pageNumber < 1 || pageSize < 1 || pageSize > 50)
            {
                return BadRequest( new{success = false , message = "Page number and page size must be greater than 0 and less than or equal to 50."});
            }
            var result = await _studentService.GetStudentsAsync(pageNumber, pageSize, search, isActive);
            return Ok(new{success = true, data = result});
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetStudentById(int id)
        {
            var result = await _studentService.GetStudentByIdAsync(id);
            
            if (result == null) 
            {
                return NotFound(new { success = false, message = "Student not found." });
            }

            return Ok(new { success = true, data = result });
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
        {
            var result = await _studentService.CreateStudentAsync(request);
            
            if (!result.IsSuccess) 
            {
                return BadRequest(new { success = false, message = result.ErrorMessage });
            }

            return Ok(new { success = true, message = "Student created successfully.", data = result.Data });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentRequest request)
        {
            var result = await _studentService.UpdateStudentAsync(id, request);
            
            if (!result.IsSuccess) 
            {
                return NotFound(new { success = false, message = result.ErrorMessage });
            }

            return Ok(new { success = true, message = "Student updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            
            if (!result.IsSuccess) 
            {
                return NotFound(new { success = false, message = result.ErrorMessage });
            }

            return Ok(new { success = true, message = "Student deleted successfully." });
        }
        
    }
}