using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services
{
    public interface RecipesInterface
    {
        public string returnV(string data);
        public Recipe GetRecipe(int id);
        public List<Recipe> GetAllRecipes();
        public void DeleteRecipe(int id);
        public void AddRecipe(Recipe recipe);
        public void UpdateRecipe(Recipe recipe);
    }
}
