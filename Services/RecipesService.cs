using Recipes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services
{
    public class RecipesService : RecipesInterface
    {
        public PraksaDBContext praksaDBContext = new PraksaDBContext();

        public string returnV(string data)
        {
            return data;
        }

        public Recipe GetRecipe(int id)
        {
            return praksaDBContext.Recipes.Find(id);
        }

        public List<Recipe> GetAllRecipes()
        {
            return praksaDBContext.Recipes.ToList();
        }

        public void DeleteById(int id)
        {
            praksaDBContext.Recipes.Remove(praksaDBContext.Recipes.Find(id));
            praksaDBContext.SaveChanges();
        }

        public void AddRecipe(Recipe recipe)
        {
            praksaDBContext.Add(recipe);
            praksaDBContext.SaveChanges();
        }
    }
}
    