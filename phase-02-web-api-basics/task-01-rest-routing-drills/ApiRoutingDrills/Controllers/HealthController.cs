using Microsoft.AspNetCore.Mvc;


namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        //
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new
            {
                status = "running",
                service = "TechMaster API",
                time = DateTime.UtcNow
            });
        }

    }

}