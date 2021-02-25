using System.ComponentModel.DataAnnotations;

namespace OnlineStore.WebUI.Data.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Slug { get; set; }

        [Required]
        public string Type { get; set; }        
    }
}