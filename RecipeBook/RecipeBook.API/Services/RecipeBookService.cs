using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeBook.API.Dtos;
using RecipeBook.API.Models;
using RecipeBook.API.ViewModels;
using System.Linq.Expressions;

namespace RecipeBook.API.Services
{
    public class RecipeBookService : IRecipeBookService
    {
        private readonly RecipeBookContext _context;
        private readonly IMapper _mapper;
        public RecipeBookService(RecipeBookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<RecipeVM> CreateRecipeAsync(NewRecipeDto x)
        {
            var m = _mapper.Map<Recipe>(x);

            _context.Recipes.Add(m);
            await _context.SaveChangesAsync();

            return _mapper.Map<RecipeVM>(m); 
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

        public async Task<List<RecipeRowVM>> GetAllRecipesAsync()
        {
            return await _context
                .Recipes
                .Select(x => _mapper.Map<RecipeRowVM>(x))
                .ToListAsync();
        }

        public async Task<RecipeVM> GetRecipeByIdAsync(int id)
        {
            return await _context
                .Recipes
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<RecipeVM>(x))
                .SingleOrDefaultAsync();
        }

        public async Task<List<RecipeRowVM>> GetRecipesWhereAsync(Expression<Func<Recipe, bool>> predicate)
        {
            return await _context
                .Recipes
                .Where(predicate)
                .Select(x => _mapper.Map<RecipeRowVM>(x))
                .ToListAsync();
        }

        public async Task<bool> UpdateRecipeAsync(int id, UpdateRecipeDto x)
        {
            var m = _mapper.Map<Recipe>(x);
            
            _context.Entry(m).State = EntityState.Modified;
            var n = await _context.SaveChangesAsync();

            return n == 1;
        }
    }
}
