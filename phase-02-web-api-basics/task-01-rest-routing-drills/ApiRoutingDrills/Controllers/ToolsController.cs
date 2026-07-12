using Microsoft.AspNetCore.Mvc;
using System;


namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : ControllerBase
    {
        // Drill 02: Route Parameter Echo (GET /api/tools/echo/{name})
        [HttpGet("echo/{name}")]
        public IActionResult Echo(string name)
        {   
            
            if (string.IsNullOrEmpty(name))
            {
                

                return BadRequest(new
                {
                    success = false,
                    message = "validation Error - name is required",
                    errors= new[] { "name is required" }
                });
            }
            

            return Ok(new
            {
                originalName = name,
                message = $"Hello, {name}! Welcome to TechMaster Academy."
            });
        }

        
    }
}
