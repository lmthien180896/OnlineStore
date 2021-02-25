using OnlineStore.UseCase.Products;
using System.Collections.Generic;

namespace OnlineStore.UseCase.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Type { get; set; }

        public List<ProductDto> Products { get; set; }
    }
}