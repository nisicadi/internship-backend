using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services;
using System;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService _recipesInterface;
        public RecipesController(IRecipesService recipesInterface)
        {
            this._recipesInterface = recipesInterface;
        }


        [HttpGet]
        public List<Recipe> Get()
        {
            return _recipesInterface.GetAllRecipes();
        }

        [HttpGet("{id}")]
        public Recipe GetById(int id)
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
