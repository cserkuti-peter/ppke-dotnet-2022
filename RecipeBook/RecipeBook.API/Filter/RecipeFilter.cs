namespace RecipeBook.API.Filter
{
    public class RecipeFilter
    {
        public string NameTerm { get; set; }
        public int? MinRating { get; set; }
        public int? MaxRating { get; set; }
    }

}
