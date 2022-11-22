using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RecipeBook.API.Dtos;
using RecipeBook.API.Filter;
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
        public async Task<RecipeVM> CreateRecipeAsync(int recipeBookId, NewRecipeDto x)
        {
            var m = _mapper.Map<Recipe>(x);

            var book = await _context.RecipeBooks.FindAsync(recipeBookId);
            if (book == null)
                return null;

            book.RecipesNumber++;

            //  1. Set the foreign key id
            m.RecipeBookId = recipeBookId;

            //  2. Set the foreign key by navigation property
            //m.RecipeBook = book;

            _context.Recipes.Add(m);
            await _context.SaveChangesAsync();

            return _mapper.Map<RecipeVM>(m); 
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            var r = await _context.Recipes.FindAsync(id);
            if (r == null)
                return false;

            _context.Recipes.Remove(r);

            //  1. Get the recipebook by a separate query
            var recipeBook = await _context.RecipeBooks.FindAsync(r.RecipeBookId);
            recipeBook.RecipesNumber--;

            //  2. Explicitely load navigation property
            //await _context
            //    .Entry(r)
            //    .Reference(x => x.RecipeBook)
            //    .LoadAsync();
            //r.RecipeBook.RecipesNumber--;

            //  3. Using lazy loading

            //_context.Entry(new Recipe { Id = id }).State = EntityState.Deleted;

            var n = await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<RecipeRowVM>> GetAllRecipesAsync(GenericQueryOption<RecipeFilter> option)
        {
            var q = _context.Recipes as IQueryable<Recipe>;
            if (!String.IsNullOrEmpty(option.Filter?.NameTerm))
            {
                q = q.Where(x => x.Name.Contains(option.Filter.NameTerm));
            }
            if (option.Filter?.MinRating != null)
            {
                q = q.Where(x => x.RatingsAvg >= option.Filter.MinRating);
            }
            if (option.Filter?.MaxRating != null)
            {
                q = q.Where(x => x.RatingsAvg <= option.Filter.MaxRating);
            }

            q = option.SortOrder == SortOrder.Ascending
                ? q.OrderBy(x => x.Name)
                : q.OrderByDescending(x => x.Name);

            return await q
                .Skip((option.Page - 1) * option.PageSize)
                .Take(option.PageSize)
                //.Select(x => new RecipeRowVM
                //{
                //   Id = x.Id,
                //   Name = x.Name,
                //   RatingsAvg = x.RatingsAvg,
                //   RecipeBookName = x.RecipeBook.Name
                //})
                .ProjectTo<RecipeRowVM>(_mapper.ConfigurationProvider)
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
