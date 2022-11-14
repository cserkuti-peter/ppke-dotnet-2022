using Microsoft.EntityFrameworkCore;

namespace RecipeBook.API.Models
{
    public class RecipeBookContext : DbContext
    {
        public RecipeBookContext(DbContextOptions<RecipeBookContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  One-to-many
            //modelBuilder.Entity<Recipe>()
            //    .HasOne<RecipeBook>(r => r.RecipeBook)
            //    .WithMany(rb => rb.Recipes)
            //    .HasForeignKey(r => r.RecipeBookId);

            //  Many-to-many
            //modelBuilder.Entity<Recipe>()
            //    .HasMany<Category>(r => r.Categories)
            //    .WithMany(c => c.Recipes)
            //    .UsingEntity(j => j.ToTable("CategoryRecipe"));

            modelBuilder.Entity<RecipeBook>().HasData(
                new RecipeBook { Id = 1, Name = "My recipe book", Description="..." }
                );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe {Id = 1, Name = "Apple pie", CookTime = 12, Ingredients = "3 Eggs", Method = "Cook", RatingsAvg = 0.5, RecipeBookId = 1},
                new Recipe {Id = 2, Name = "Apple pie2", CookTime = 10, Ingredients = "2 Eggs", Method = "Cook", RatingsAvg = 0.5, RecipeBookId = 1}
                );
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RecipeBook> RecipeBooks { get; set; }

    }
}
