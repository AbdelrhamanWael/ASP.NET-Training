using System;
using Microsoft.AspNetCore.Mvc;
using BookStoreApi.DTOs;
using BookStoreApi.Services;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService) => _authorService = authorService;
        [HttpGet]
        public IEnumerable<AuthorResponse> GetAll() => _authorService.GetAll();

        [HttpPost]
        public IActionResult Create([FromBody] CreateAuthorRequest request)
        {
            try
            {
                var response = _authorService.Create(request);
                return StatusCode(201, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }

}

