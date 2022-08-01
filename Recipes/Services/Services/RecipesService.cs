using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class RecipesService : IRecipesService
    {
        private PraksaDBContext praksaDBContext;
        public RecipesService(PraksaDBContext praksaDBContext)
        {
            this.praksaDBContext = praksaDBContext;
        }

        public Recipe GetRecipe(int id)
        {
            return praksaDBContext.Recipes.Find(id);
        }

        public List<Recipe> GetAllRecipes()
        {
            return praksaDBContext.Recipes.ToList();
        }

        public void DeleteRecipe(int id)
        {
            praksaDBContext.Recipes.Remove(GetRecipe(id));
            praksaDBContext.SaveChanges();
        }

        public void AddRecipe(Recipe recipe)
        {
            praksaDBContext.Recipes.Add(recipe);
            praksaDBContext.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            praksaDBContext.Recipes.Update(recipe);
            praksaDBContext.SaveChanges();
        }
    }
}
