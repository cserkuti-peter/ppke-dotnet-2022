namespace RecipeBook.API.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public int CookTime { get; set; }
        public int Serves { get; set; }
    }
}
