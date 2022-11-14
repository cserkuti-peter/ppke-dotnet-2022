﻿using RecipeBook.API.Dtos;
using RecipeBook.API.Models;
using RecipeBook.API.ViewModels;
using System.Linq.Expressions;

namespace RecipeBook.API.Services
{
    public interface IRecipeBookService
    {
        Task<RecipeVM> CreateRecipeAsync(NewRecipeDto r);
        Task<bool> DeleteRecipeAsync(int id);
        Task<List<RecipeRowVM>> GetAllRecipesAsync();
        Task<RecipeVM> GetRecipeByIdAsync(int id);
        Task<List<RecipeRowVM>> GetRecipesWhereAsync(Expression<Func<Recipe, bool>> predicate);
        Task<bool> UpdateRecipeAsync(int id, UpdateRecipeDto r);
    }
}