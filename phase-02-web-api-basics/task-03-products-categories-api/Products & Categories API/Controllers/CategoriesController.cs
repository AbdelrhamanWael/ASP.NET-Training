using Microsoft.AspNetCore.Mvc;
using Products___Categories_API.DTOs;
using Products___Categories_API.Services;



namespace Products___Categories_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_categoryService.GetAll());

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryRequest request)
        {
            var response = _categoryService.Create(request);
            return StatusCode(201, response);
        }
    }

}