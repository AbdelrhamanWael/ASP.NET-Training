using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("add")]
        public IActionResult Add([FromQuery] decimal a, [FromQuery] decimal b)
        {
            return Ok(new
            {
                a = a,
                b = b,
                operation = "add",
                result = a + b
            });
        }
        
    }
}
