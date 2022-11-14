namespace RecipeBook.API.ViewModels
{
    public class RecipeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Ingredients { get; set; }
        public string Method { get; set; }
        public int CookTimeMinutes { get; set; }
        public int Serves { get; set; }
        public double RatingsAvg { get; set; }
    }
}
