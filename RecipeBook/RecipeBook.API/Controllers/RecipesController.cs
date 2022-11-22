using Microsoft.AspNetCore.Mvc;
using RecipeBook.API.Dtos;
using RecipeBook.API.Filter;
using RecipeBook.API.Models;
using RecipeBook.API.Services;
using RecipeBook.API.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeBook.API.Controllers
{
    [Route("api")]
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
        [HttpGet("recipes")]
        public async Task<IEnumerable<RecipeRowVM>> GetAll([FromQuery] GenericQueryOption<RecipeFilter> option)
        {
            //throw new Exception("Test exception");

            _logger.LogInformation("GetAll called.");

            return await _recipeBookService.GetAllRecipesAsync(option);
        }

        // GET api/<RecipesController>/5
        [HttpGet("recipes/{id}")]
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
        [HttpPost("recipebook/{recipeBookId}/recipes")]
        public async Task<IActionResult> Post(int recipeBookId, [FromBody] NewRecipeDto recipe)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var createdRecipe = await _recipeBookService.CreateRecipeAsync(recipeBookId, recipe);
            if (createdRecipe == null)
                return NotFound();

            return CreatedAtAction(nameof(GetById), new { Id = createdRecipe.Id }, createdRecipe);
        }

        // PUT api/<RecipesController>/5
        [HttpPut("recipes/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateRecipeDto recipe)
        {
            return await _recipeBookService.UpdateRecipeAsync(id, recipe)
                ? NoContent()
                : NotFound();
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("recipes/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return await _recipeBookService.DeleteRecipeAsync(id)
                ? NoContent()
                : NotFound();
        }
    }
}
