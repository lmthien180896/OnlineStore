using System.Collections.Generic;

namespace OnlineStore.WebAPI.Contracts
{
    public class CategoryContract
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Type { get; set; }

        public List<ProductContract> Products { get; set; }
    }
}