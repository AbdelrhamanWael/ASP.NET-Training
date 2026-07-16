using System;

namespace BookStoreApi.Models
{
    public class Category
    {
        public int CategoryId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        private Category() { }

        public Category(int categoryId, string name, string description, bool isActive)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}