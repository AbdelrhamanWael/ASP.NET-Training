using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradesController : ControllerBase
    {
        //Drill 05: Grade API
        [HttpGet("calculate")]
        public IActionResult GetGrade([FromQuery] int grade)
        {
            if(grade < 0 || grade > 100)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "validation Error - grade must be between 0 and 100",
                    errors = new[] { "grade must be between 0 and 100" }
                }
                );
            }
            return Ok(new
            {
                grade = grade,
                message = grade switch
                {
                    >= 90 => "A",
                    >= 80 => "B",
                    >= 70 => "C",
                    >= 60 => "D",
                    _ => "F"
                }
            });
        }
    }
}