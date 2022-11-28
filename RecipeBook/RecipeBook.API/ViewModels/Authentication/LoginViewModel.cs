namespace RecipeBook.API.ViewModels.Authentication
{
    public class LoginViewModel
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
