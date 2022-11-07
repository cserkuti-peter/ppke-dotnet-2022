using RecipeBook.API.Models;
using System.Linq.Expressions;

namespace RecipeBook.API.Services
{
    public interface IRecipeBookService
    {
        Task<Recipe> CreateRecipeAsync(Recipe r);
        Task<bool> DeleteRecipeAsync(int id);
        Task<List<Recipe>> GetAllRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<List<Recipe>> GetRecipesWhereAsync(Expression<Func<Recipe, bool>> predicate);
        Task<bool> UpdateRecipeAsync(int id, Recipe r);
    }
}