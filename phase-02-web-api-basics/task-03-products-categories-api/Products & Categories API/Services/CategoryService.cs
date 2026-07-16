using Products___Categories_API.DTOs;
using Products___Categories_API.Models;

namespace Products___Categories_API.Services
{
    public class CategoryService : ICategoryService
    {
        private static readonly List<Category> Categories = new(){
            new Category(1, "Electronics", "Gadgets and devices", true),
            new Category(2, "Furniture", "Home and office furniture", true),
            new Category(3, "Stationery", "Office and school supplies", true),
            new Category(4, "Accessories", "Fashion and utility accessories", true)
        };
        private static int _nextId = 5;

        public Category Create(CreateCategoryRequest request) { 
            var category = new Category(_nextId++, request.Name, request.Description, true);
            Categories.Add(category);
            return category;
        }
        public IEnumerable<Category> GetAll() => Categories;
        public bool Exists(int categoryId) => Categories.Any(c => c.CategoryId == categoryId && c.IsActive);

        public string GetNameById(int categoryId) => 
            Categories.FirstOrDefault(c => c.CategoryId == categoryId)?.Name ?? "Unknown";
    }
        
}


