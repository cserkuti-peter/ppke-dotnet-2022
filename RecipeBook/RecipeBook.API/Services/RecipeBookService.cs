using Microsoft.EntityFrameworkCore;
using RecipeBook.API.Models;
using System.Linq.Expressions;

namespace RecipeBook.API.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private readonly RecipeBookContext _context;
        public RecipeBookService(RecipeBookContext context)
        {
            _context = context;
        }
        public async Task<Recipe> CreateRecipeAsync(Recipe r)
        {
            _context.Recipes.Add(r);
            await _context.SaveChangesAsync();

            return r;
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            //var r = await _context.Recipes.FindAsync(id);
            //if (r == null)
            //    return false;

            //_context.Recipes.Remove(r);
            
            _context.Entry(new Recipe { Id = id }).State = EntityState.Deleted;

            var n = await _context.SaveChangesAsync();

            return n == 1;
        }

        public async Task<List<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<List<Recipe>> GetRecipesWhereAsync(Expression<Func<Recipe, bool>> predicate)
        {
            return await _context.Recipes.Where(predicate).ToListAsync();
        }

        public async Task<bool> UpdateRecipeAsync(int id, Recipe r)
        {
            _context.Entry(r).State = EntityState.Modified;
            var n = await _context.SaveChangesAsync();

            return n == 1;
        }
    }
}
