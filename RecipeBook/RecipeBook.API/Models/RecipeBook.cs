using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeBook.API.Models
{
    //[Table("RecipeCollection")]
    public class RecipeBook
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Column("CollectionName")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int RecipesNumber { get; set; }
        public ICollection<Recipe> Recipes { get; set; }
    }
}
