using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Model
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Slug { get; set; }

        [Required]
        [MaxLength(200)]
        public string Type { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}