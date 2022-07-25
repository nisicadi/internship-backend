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
        private readonly RecipesService recipesService = new RecipesService();


        [HttpGet]

        public List<Recipe> Get()
        {
            return recipesService.GetAllRecipes();
        }

        [HttpGet("{id}")]
        public Recipe GetById(int id)
        {
            return recipesService.GetRecipe(id);
        }

        //[HttpGet("delete{id}")]
        //public void DeleteById(int id)
        //{
        //    recipesService.DeleteById(id);
        //}

        [HttpDelete("{id}")]
        public void DeleteById(int id)
        {
            recipesService.DeleteById(id);
        }

    }
}
