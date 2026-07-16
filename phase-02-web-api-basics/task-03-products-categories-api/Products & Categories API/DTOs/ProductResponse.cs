using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products___Categories_API.Models.DTOs
{
    public class ProductResponse
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public bool IsAvailable { get; set; }
        public string SupplierName { get; set; } = string.Empty;
    }

    public class UpdateStockRequest
    {
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int NewQuantity { get; set; }
    }

    public class StockValueReportResponse
    {
        public decimal TotalSystemStockValue { get; set; }
        public List<CategoryStockValueDetail> CategoryBreakdown { get; set; } = new();
    }

    public class CategoryStockValueDetail
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int TotalItemsInStock { get; set; }
        public decimal TotalValue { get; set; }
    }
}