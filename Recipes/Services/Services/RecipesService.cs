using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class RecipesService : IRecipesService
    {
        private PraksaDBContext praksaDBContext;
        private PraksaDBContext praksaDBContext1;
        public RecipesService(PraksaDBContext praksaDBContext, PraksaDBContext praksaDBContext1)
        {
            this.praksaDBContext = praksaDBContext;
            this.praksaDBContext1 = praksaDBContext1;
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
            {
                praksaDBContext.Ingredients.Remove(ingredient);
                Storage storage = praksaDBContext.Storages.Where(o => o.FoodstuffId == ingredient.FoodstuffId).First();
                storage.Quantity += ingredient.Quantity;
                storage.UnderMin = storage.Quantity < storage.MinQuantity;
                praksaDBContext.Storages.Update(storage);
            }

            praksaDBContext.Recipes.Remove(GetRecipe(id));
            praksaDBContext.SaveChanges();
        }

        public void AddRecipe(Recipe recipe)
        {
            recipe.Category = praksaDBContext.Categories.Find(recipe.CategoryId);
            foreach(var ingredient in recipe.Ingredients)
            {
                ingredient.Foodstuff = praksaDBContext.Foodstuffs.Find(ingredient.FoodstuffId);

                Storage storage = praksaDBContext.Storages.Where(o => o.FoodstuffId == ingredient.FoodstuffId).First();
                storage.Quantity -= ingredient.Quantity;
                storage.UnderMin = storage.Quantity < storage.MinQuantity;
                praksaDBContext.Storages.Update(storage);
            }

            praksaDBContext.Recipes.Add(recipe);
            praksaDBContext.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            recipe.Category = praksaDBContext.Categories.Find(recipe.CategoryId);
            Recipe oldRecipe = praksaDBContext.Recipes.Find(recipe.RecipeId);

            //Remove old quantities
            foreach (var ingredient in oldRecipe.Ingredients)
            {
                ingredient.Foodstuff = praksaDBContext.Foodstuffs.Find(ingredient.FoodstuffId);

                Storage storage = praksaDBContext.Storages.Where(o => o.FoodstuffId == ingredient.FoodstuffId).First();
                storage.Quantity += ingredient.Quantity;
                storage.UnderMin = storage.Quantity < storage.MinQuantity;
                praksaDBContext.Storages.Update(storage);
            }

            //Add new quantities from recipe ingredient to storage
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Foodstuff = praksaDBContext.Foodstuffs.Find(ingredient.FoodstuffId);

                Storage storage = praksaDBContext.Storages.Where(o => o.FoodstuffId == ingredient.FoodstuffId).First();
                storage.Quantity -= ingredient.Quantity;
                storage.UnderMin = storage.Quantity < storage.MinQuantity;
                praksaDBContext.Storages.Update(storage);

            }

            //https://stackoverflow.com/questions/68530015/the-instance-of-entity-type-company-cannot-be-tracked-because-another-instance
            praksaDBContext.Entry(oldRecipe).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            praksaDBContext.Recipes.Update(recipe);
            praksaDBContext.SaveChanges();
        }
    }
}
