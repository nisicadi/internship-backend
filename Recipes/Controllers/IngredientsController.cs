using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService _ingredientsInterface;
        public IngredientsController(IIngredientsService ingredientsInterface)
        {
            _ingredientsInterface = ingredientsInterface;
        }

        //Categories
        [HttpGet]
        public List<Ingredient> GetAllIngredients()
        {
            return _ingredientsInterface.GetAllIngredients();
        }

        [HttpGet("{id}")]
        public Ingredient GetIngredientById(int id)
        {
            return _ingredientsInterface.GetIngredient(id);
        }

        [HttpDelete("{id}")]
        public void DeleteIngredient(int id)
        {
            _ingredientsInterface.DeleteIngredient(id);
        }

        [HttpPost]
        public void AddIngredient(Ingredient ingredient)
        {
            _ingredientsInterface.AddIngredient(ingredient);
        }

        [HttpPut("{id}")]
        public void UpdateIngredient(Ingredient ingredient)
        {
            _ingredientsInterface.UpdateIngredient(ingredient);
        }
    }
}
