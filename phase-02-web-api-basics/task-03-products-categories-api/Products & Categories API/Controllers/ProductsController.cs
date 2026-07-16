using System;
using Microsoft.AspNetCore.Mvc;
using Products___Categories_API.DTOs;
using Products___Categories_API.Models.DTOs;
using Products___Categories_API.Services;

namespace Products___Categories_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] string? search,
            [FromQuery] int? categoryId,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] bool? isAvailable)
        {
            return Ok(_productService.GetAll(search, categoryId, minPrice, maxPrice, isAvailable));
        }

        [HttpGet("low-stock")]
        public IActionResult GetLowStock([FromQuery] int threshold = 5)
        {
            return Ok(_productService.GetLowStock(threshold));
        }

        [HttpGet("reports/stock-value")]
        public IActionResult GetStockValueReport()
        {
            return Ok(_productService.GetStockValueReport());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product == null) return NotFound(new { message = $"Product with ID {id} not found." });
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductRequest request)
        {
            try
            {
                var response = _productService.Create(request);
                return StatusCode(201, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateProductRequest request)
        {
            try
            {
                var response = _productService.Update(id, request);
                if (response == null) return NotFound(new { message = $"Product with ID {id} not found." });
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPatch("{id:int}/stock")]
        public IActionResult UpdateStock(int id, [FromBody] UpdateStockRequest request)
        {
            var response = _productService.UpdateStock(id, request.NewQuantity);
            if (response == null) return NotFound(new { message = $"Product with ID {id} not found." });
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var success = _productService.Delete(id);
            if (!success) return NotFound(new { message = $"Product with ID {id} not found." });
            return NoContent();
        }
    }

}