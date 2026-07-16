using Products___Categories_API.DTOs;
using Products___Categories_API.Models;

namespace Products___Categories_API.Services
{
    public class CategoryService : ICategoryService
    {
        private static readonly List<Category> Categories = new(){
            new Category { CategoryId = 1, Name = "Electronics", Description = "Gadgets and devices", IsActive = true, CreatedDate = DateTime.UtcNow },
            new Category { CategoryId = 2, Name = "Furniture", Description = "Home and office furniture", IsActive = true, CreatedDate = DateTime.UtcNow },
            new Category { CategoryId = 3, Name = "Stationery", Description = "Office and school supplies", IsActive = true, CreatedDate = DateTime.UtcNow },
            new Category { CategoryId = 4, Name = "Accessories", Description = "Fashion and utility accessories", IsActive = true, CreatedDate = DateTime.UtcNow }
        };
        private static int _nextId = 5;

        public Category Create(CreateCategoryRequest request) { 
            var category = new Category
            {
                CategoryId = _nextId++,
                Name = request.Name,
                Description = request.Description,
                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };
            Categories.Add(category);
            return category;
        }
        public IEnumerable<Category> GetAll() => Categories;
        public bool Exists(int categoryId) => Categories.Any(c => c.CategoryId == categoryId && c.IsActive);

        public string GetNameById(int categoryId) => 
            Categories.FirstOrDefault(c => c.CategoryId == categoryId)?.Name ?? "Unknown";
    }
        
}


