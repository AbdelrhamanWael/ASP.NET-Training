using System;
using Microsoft.AspNetCore.Mvc;
using BookStoreApi.DTOs;
using BookStoreApi.Services;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll(
            [FromQuery] string? search,
            [FromQuery] int? categoryId,
            [FromQuery] int? authorId,
            [FromQuery] bool? isAvailable,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            return Ok(_bookService.GetAll(search, categoryId, authorId, isAvailable, pageNumber, pageSize));
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null) return NotFound(new { message = $"Book with ID {id} not found." });
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookRequest request)
        {
            try
            {
                var response = _bookService.Create(request);
                return StatusCode(201, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateBookRequest request)
        {
            try
            {
                var response = _bookService.Update(id, request);
                if (response == null) return NotFound(new { message = $"Book with ID {id} not found." });
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var success = _bookService.Delete(id);
            if (!success) return NotFound(new { message = $"Book with ID {id} not found." });
            return NoContent();
        }

        [HttpGet("reports/summary")]
        public IActionResult GetSummaryReport()
        {
            return Ok(_bookService.GetSummaryReport());
        }
    }
}