using Microsoft.AspNetCore.Mvc;
using RecipeBook.API.Models;
using RecipeBook.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeBookService _recipeBookService;
        public RecipesController(RecipeBookService service)
        {
            _recipeBookService = service;
        }

        // GET: api/<RecipesController>
        [HttpGet]
        public IEnumerable<Recipe> GetAll()
        {
            return _recipeBookService.GetAllRecipes();
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var r = _recipeBookService.GetRecipeById(id);

            if (r == null)
            {
                return NotFound();
            }

            return Ok(r);
        }

        // POST api/<RecipesController>
        [HttpPost]
        public IActionResult Post([FromBody] Recipe recipe)
        {
            var createdRecipe = _recipeBookService.CreateRecipe(recipe);

            return CreatedAtAction(nameof(GetById), new { Id = createdRecipe.Id }, createdRecipe);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Recipe recipe)
        {
            return _recipeBookService.UpdateRecipe(id, recipe)
                ? NoContent()
                : NotFound();
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return _recipeBookService.DeleteRecipe(id)
                ? NoContent()
                : NotFound();
        }
    }
}
