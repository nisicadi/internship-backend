using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services.Interfaces
{
    public interface IIngredientsService
    {
        public Ingredient GetIngredient(int id);
        public List<Ingredient> GetAllIngredients();
        public void DeleteIngredient(int id);
        public void AddIngredient(Ingredient ingredient);
        public void UpdateIngredient(Ingredient ingredient);
    }
}
