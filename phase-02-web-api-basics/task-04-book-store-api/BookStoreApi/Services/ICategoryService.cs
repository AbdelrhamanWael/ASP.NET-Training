using System.Collections.Generic;
using BookStoreApi.DTOs;

namespace BookStoreApi.Services
{
    public interface ICategoryService
    {
        CategoryResponse Create(CreateCategoryRequest request);
        IEnumerable<CategoryResponse> GetAll();
        bool Exists(int categoryId);
        string GetNameById(int categoryId);
    }
}