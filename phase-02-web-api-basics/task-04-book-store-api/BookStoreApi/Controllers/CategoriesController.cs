
using System;
using Microsoft.AspNetCore.Mvc;
using BookStoreApi.DTOs;
using BookStoreApi.Services;

namespace BookStoreApi.Controllers
{
    [ApiController]
    [Route("api/categories")]

    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService) => _categoryService = categoryService;
        [HttpGet]
        public IEnumerable<CategoryResponse> GetAll() => _categoryService.GetAll(); 

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryRequest request)
        {
            try
            {
                var response = _categoryService.Create(request);
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
