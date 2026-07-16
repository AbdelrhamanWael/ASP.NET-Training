using System.ComponentModel.DataAnnotations;

namespace Products___Categories_API.DTOs
{
    public class CreateCategoryRequest
    {
        [Required(ErrorMessage = "Category Name is required.")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}