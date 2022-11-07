using RecipeBook.API.Models;

namespace RecipeBook.API.Services
{
    public class RecipeBookServiceInMemory //: IRecipeBookService
    {
        private List<Recipe> recipes = new List<Recipe>
        {
            new Recipe {
                Id = 1,
                Name = "Apple pie",
                Ingredients = "3 eggs, 1tbs milk, ...",
                Method = "1. Separate eggs...",
                CookTime = 30,
                Serves = 6
            },
            new Recipe {
                Id = 2,
                Name = "Apple pie 2",
                Ingredients = "3 eggs, 1tbs milk, ...",
                Method = "1. Separate eggs...",
                CookTime = 30,
                Serves = 6
            },
        };

        public Recipe CreateRecipe(Recipe r)
        {
            r.Id = recipes.Max(x => x.Id) + 1;
            recipes.Add(r);
            return r;
        }

        public List<Recipe> GetAllRecipes()
        {
            return recipes.ToList();
        }

        public List<Recipe> GetRecipesWhere(Func<Recipe, bool> predicate)
        {
            return recipes.Where(predicate).ToList();
        }

        public Recipe GetRecipeById(int id)
        {
            return recipes.SingleOrDefault(x => x.Id == id);
        }

        public bool UpdateRecipe(int id, Recipe r)
        {
            var recipeToUpdate = recipes.SingleOrDefault(x => x.Id == id);

            if (recipeToUpdate == null)
                return false;

            recipeToUpdate.Name = r.Name;
            recipeToUpdate.Serves = r.Serves;
            recipeToUpdate.CookTime = r.CookTime;
            recipeToUpdate.Method = r.Method;
            recipeToUpdate.Ingredients = r.Ingredients;

            return true;
        }

        public bool DeleteRecipe(int id)
        {
            int n = recipes.RemoveAll(x => x.Id == id);

            return n == 1;
        }
    }
}
