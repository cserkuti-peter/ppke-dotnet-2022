using Microsoft.EntityFrameworkCore;

namespace RecipeBook.API.Models
{
    public class RecipeBookContext : DbContext
    {
        public RecipeBookContext(DbContextOptions<RecipeBookContext> options) 
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
