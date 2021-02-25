using OnlineStore.UseCase.Categories;
using System;

namespace OnlineStore.UseCase.Products
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        public decimal DiscountPercent { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }

        public CategoryDto Category { get; set; }

        public string Image { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}