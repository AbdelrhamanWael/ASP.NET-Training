using Microsoft.AspNetCore.Mvc;
using System;

namespace ApiRoutingDrills.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConverterController : ControllerBase
    {
        //Drill 04 - Temperature Conversion API
        [HttpGet("convert from celsius to fahrenheit")]
        public IActionResult CelsiusToFahrenheit([FromQuery] decimal celsius)
        {
            if(celsius < 0)

            {
                return BadRequest();
            }
            return Ok(new
            {
                celsius = celsius,
                operation = "convert from celsius to fahrenheit",
                result = celsius * 1.8m + 32m
            });
        }
    }
}