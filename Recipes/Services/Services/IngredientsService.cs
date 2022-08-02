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
            praksaDBContext.Ingredients.Remove(GetIngredient(id));
            praksaDBContext.SaveChanges();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            praksaDBContext.Ingredients.Add(ingredient);
            praksaDBContext.SaveChanges();
        }
    }
}
