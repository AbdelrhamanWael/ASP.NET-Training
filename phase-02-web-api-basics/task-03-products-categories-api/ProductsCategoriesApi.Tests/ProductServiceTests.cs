using System;
using System.Linq;
using Moq;
using Xunit;
using Products___Categories_API.Models;
using Products___Categories_API.DTOs;
using ProductsCategoriesApi.Services;
using Products___Categories_API.Services;

namespace ProductsCategoriesApi.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<ICategoryService> _mockCategoryService;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockCategoryService = new Mock<ICategoryService>();
            // Make sure the mock returns true for category 1
            _mockCategoryService.Setup(cs => cs.Exists(1)).Returns(true);
            _mockCategoryService.Setup(cs => cs.Exists(99)).Returns(false);

            _productService = new ProductService(_mockCategoryService.Object);
        }

        [Fact]
        public void Create_WithValidCategory_ReturnsProductResponse()
        {
            // Arrange
            var request = new CreateProductRequest
            {
                Name = "Test Product",
                CategoryId = 1,
                Price = 10.99m,
                StockQuantity = 5,
                SupplierName = "Test Supplier"
            };

            // Act
            var result = _productService.Create(request);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Product", result.Name);
            Assert.True(result.IsAvailable); // because stock > 0
        }

        [Fact]
        public void Create_WithInvalidCategory_ThrowsArgumentException()
        {
            // Arrange
            var request = new CreateProductRequest
            {
                Name = "Invalid Product",
                CategoryId = 99,
                Price = 10.99m,
                StockQuantity = 5,
                SupplierName = "Test Supplier"
            };

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => _productService.Create(request));
            Assert.Contains("does not exist", exception.Message);
        }

        [Fact]
        public void UpdateStock_WhenStockDropsToZero_IsAvailableBecomesFalse()
        {
            // Arrange (Create first)
            var request = new CreateProductRequest
            {
                Name = "Stock Product",
                CategoryId = 1,
                Price = 15.00m,
                StockQuantity = 10,
                SupplierName = "Supplier"
            };
            var product = _productService.Create(request);

            // Act
            var updatedProduct = _productService.UpdateStock(product!.ProductId, 0);

            // Assert
            Assert.NotNull(updatedProduct);
            Assert.Equal(0, updatedProduct.StockQuantity);
            Assert.False(updatedProduct.IsAvailable);
        }
    }
}
