using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class FoodstuffService : IFoodstuffService
    {
        private PraksaDBContext praksaDBContext;
        public FoodstuffService(PraksaDBContext praksaDBContext)
        {
            this.praksaDBContext = praksaDBContext;
        }

        public Foodstuff GetFoodstuff(int id)
        {
            return praksaDBContext.Foodstuffs.Find(id);
        }

        public List<Foodstuff> GetAllFoodstuffs()
        {
            return praksaDBContext.Foodstuffs.ToList();
        }

        public void DeleteFoodstuff(int id)
        {
            praksaDBContext.Foodstuffs.Remove(GetFoodstuff(id));
            praksaDBContext.SaveChanges();
        }

        public void AddFoodstuff(Foodstuff foodstuff)
        {
            foodstuff.Measurement = praksaDBContext.MeasurementUnits.Find(foodstuff.MeasurementId);
            praksaDBContext.Foodstuffs.Add(foodstuff);
            praksaDBContext.SaveChanges();
        }

        public void UpdateFoodstuff(Foodstuff foodstuff)
        {
            praksaDBContext.Foodstuffs.Update(foodstuff);
            praksaDBContext.SaveChanges();
        }
    }
}
