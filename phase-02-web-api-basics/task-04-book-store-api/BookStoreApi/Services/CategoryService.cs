using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreApi.DTOs;
using BookStoreApi.Models;

namespace BookStoreApi.Services
{
    public class CategoryService : ICategoryService
    {
        private static readonly List<Category> _categories = new()
        {
            new Category(1, "Software Engineering", "Programming paradigms and clean practices", true),
            new Category(2, "Databases & Architecture", "SQL, NoSQL, and scaling infrastructure", true)
        };
        private static int _nextId = 3;

        public CategoryResponse Create(CreateCategoryRequest request)
        {
            // Business Rule Validation: Category Name must be unique
            if (_categories.Any(c => c.Name.Equals(request.Name, StringComparison.OrdinalIgnoreCase)))
                throw new ArgumentException("A category with this name already exists.");

            var category = new Category(_nextId++, request.Name, request.Description, true);
            _categories.Add(category);
            return MapToResponse(category);
        }

        public IEnumerable<CategoryResponse> GetAll() => _categories.Select(MapToResponse);
        public bool Exists(int categoryId) => _categories.Any(c => c.CategoryId == categoryId && c.IsActive);
        public string GetNameById(int categoryId) => _categories.FirstOrDefault(c => c.CategoryId == categoryId)?.Name ?? "Unknown Category";

        private static CategoryResponse MapToResponse(Category c) => new()
        {
            CategoryId = c.CategoryId,
            Name = c.Name,
            Description = c.Description,
            IsActive = c.IsActive
        };
    }
}