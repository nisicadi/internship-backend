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
            Recipe recipe = praksaDBContext.Recipes.Find(id);
            recipe.Ingredients = praksaDBContext.Ingredients.Where(o => o.RecipeId == recipe.RecipeId).ToList();
            recipe.Category = praksaDBContext.Categories.Where(o => o.CategoryId == recipe.CategoryId).First();
            
            return recipe;
        }

        public List<Recipe> GetAllRecipes()
        {
            List<Recipe> recipes = praksaDBContext.Recipes.ToList();
            foreach(var recipe in recipes)
            {
                recipe.Ingredients = praksaDBContext.Ingredients.Where(o => o.RecipeId == recipe.RecipeId).ToList();
                recipe.Category = praksaDBContext.Categories.Where(o => o.CategoryId == recipe.CategoryId).First();
            }

            return recipes;
        }

        public void DeleteRecipe(int id)
        {
            foreach(var ingredient in GetRecipe(id).Ingredients)
                praksaDBContext.Ingredients.Remove(ingredient);

            praksaDBContext.Recipes.Remove(GetRecipe(id));
            praksaDBContext.SaveChanges();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipe.Category = praksaDBContext.Categories.Find(recipe.CategoryId);
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
