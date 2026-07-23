using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreDrillsApi.Data;
using EFCoreDrillsApi.DTOs;


namespace EFCoreDrillsApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TracksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetTrackDetails(int id)
        {
            var track = await _context.TrainingTracks
                .Where(t => t.Id == id)
                .Select(t=> new TrackDetailsDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    InstructorName = t.Instructor.Name,
                    ActiveStudentsCount = t.Enrollments.Count(e => e.Status == "Active")
                })
                .FirstOrDefaultAsync();
                if (track == null) return NotFound("Track not found.");

                return Ok(track);
        }

    }
}