using System.ComponentModel.DataAnnotations;

namespace RecipeBook.API.Dtos
{
    public class NewRecipeDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public string? Ingredients { get; set; }
        public string Method { get; set; }
        [Range(1, 1200)]
        public int CookTime { get; set; }
        [Range(1, 12)]
        public int Serves { get; set; }
    }
}
