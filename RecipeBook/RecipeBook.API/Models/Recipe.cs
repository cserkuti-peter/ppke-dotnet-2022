using System.ComponentModel.DataAnnotations;

namespace RecipeBook.API.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Ingredients { get; set; }
        public string Method { get; set; }
        [Range(1, 1200)]
        public int CookTime { get; set; }
        [Range(1, 12)]
        public int Serves { get; set; }
    }
}
