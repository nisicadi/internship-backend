using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesInterface;
        public RecipesController(IRecipesService recipesInterface)
        {
            _recipesInterface = recipesInterface;
        }

        //Recipe
        [HttpGet]
        public List<Recipe> GetAllRecipes()
        {
            return _recipesInterface.GetAllRecipes();
        }

        [HttpGet("{id}")]
        public Recipe GetRecipeById(int id)
        {
            return _recipesInterface.GetRecipe(id);
        }

        [HttpDelete("{id}")]
        public void DeleteRecipe(int id)
        {
            _recipesInterface.DeleteRecipe(id);
        }

        [HttpPost]
        public void AddRecipe(Recipe recipe)
        {
            _recipesInterface.AddRecipe(recipe);
        }

        [HttpPut("{id}")]
        public void UpdateRecipe(Recipe recipe)
        {
            _recipesInterface.UpdateRecipe(recipe);
        }
    }
}
