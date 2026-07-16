using System.Collections.Generic;
using Products___Categories_API.DTOs;
using Products___Categories_API.Models;

namespace Products___Categories_API.Services
{
    public interface ICategoryService
    {
        Category Create(CreateCategoryRequest request);
        IEnumerable<Category> GetAll();

        bool Exists(int categoryId);

        string GetNameById(int categoryId);
    }
}