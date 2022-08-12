using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class IngredientsService : IIngredientsService
    {
        private PraksaDBContext praksaDBContext;
        public IngredientsService(PraksaDBContext praksaDBContext)
        {
            this.praksaDBContext = praksaDBContext;
        }

        public Ingredient GetIngredient(int id)
        {
            return praksaDBContext.Ingredients.Find(id);
        }

        public List<Ingredient> GetAllIngredients()
        {
            return praksaDBContext.Ingredients.ToList();
        }

        public void DeleteIngredient(int id)
        {
            Ingredient ingredient = GetIngredient(id);
            Storage storage = praksaDBContext.Storages.Where(obj => obj.FoodstuffId == ingredient.FoodstuffId).First();
            storage.Quantity += ingredient.Quantity;
            storage.UnderMin = storage.Quantity < storage.MinQuantity;
            praksaDBContext.Ingredients.Remove(ingredient);
            praksaDBContext.SaveChanges();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            //Update kolicinu u Skladistu
            Storage storage = praksaDBContext.Storages.Where(o => o.FoodstuffId == ingredient.FoodstuffId).First();
            storage.Quantity -= ingredient.Quantity;
            storage.UnderMin = storage.Quantity < storage.MinQuantity;
            praksaDBContext.Storages.Update(storage);

            praksaDBContext.Ingredients.Add(ingredient);
            praksaDBContext.SaveChanges();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            ingredient.Foodstuff = praksaDBContext.Foodstuffs.Find(ingredient.FoodstuffId);
            Storage storage = praksaDBContext.Storages.Where(o => o.FoodstuffId == ingredient.FoodstuffId).First();
            decimal oldQuantity = GetIngredient(ingredient.IngredientId).Quantity;

            //Add new quantity from ingredient to storage
            storage.Quantity += ingredient.Quantity - oldQuantity;
            storage.UnderMin = storage.Quantity < storage.MinQuantity;

            praksaDBContext.Storages.Update(storage);

            //praksaDBContext.Ingredients.Update(ingredient);
            praksaDBContext.Entry(GetIngredient(ingredient.IngredientId)).CurrentValues.SetValues(ingredient);
            praksaDBContext.SaveChanges();
        }
    }
}
