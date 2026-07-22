using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDrillsApi.Data;
namespace EFCoreDrillsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public InstructorsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id}/tracks")]
        public async Task<IActionResult> GetInstructorTracks(int id)
        {
            
            var Instructor = await _context.Instructors
                .Include(i => i.Tracks)
                .FirstOrDefaultAsync(i => i.Id == id);
            if (Instructor == null)
            {
                return NotFound("Instructor not found.");
            }
            var response = new
            {
                Instructor.Id,
                Instructor.Name,
                Tracks = Instructor.Tracks.Select(t => new
                {
                    t.Id,
                    t.Title
                })
            }
            ;
            return Ok(response);


        }
    }
}