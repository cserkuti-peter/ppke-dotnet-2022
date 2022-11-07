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
        private readonly IRecipeBookService _recipeBookService;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(IRecipeBookService service, ILogger<RecipesController> logger)
        {
            _recipeBookService = service;
            _logger = logger;
        }

        // GET: api/<RecipesController>
        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetAll(string? term = null)
        {
            //throw new Exception("Test exception");

            _logger.LogInformation("GetAll called.");

            return term == null
                ? await _recipeBookService.GetAllRecipesAsync()
                : await _recipeBookService.GetRecipesWhereAsync(x => x.Name.Contains(term));
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var r = await _recipeBookService.GetRecipeByIdAsync(id);

            if (r == null)
            {
                return NotFound();
            }

            return Ok(r);
        }

        // POST api/<RecipesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Recipe recipe)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var createdRecipe = await _recipeBookService.CreateRecipeAsync(recipe);

            return CreatedAtAction(nameof(GetById), new { Id = createdRecipe.Id }, createdRecipe);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Recipe recipe)
        {
            return await _recipeBookService.UpdateRecipeAsync(id, recipe)
                ? NoContent()
                : NotFound();
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _recipeBookService.DeleteRecipeAsync(id)
                ? NoContent()
                : NotFound();
        }
    }
}
