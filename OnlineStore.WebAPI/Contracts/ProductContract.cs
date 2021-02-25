using System;

namespace OnlineStore.WebAPI.Contracts
{
    public class ProductContract
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

        public CategoryContract Category { get; set; }

        public string Image { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }        
    }
}