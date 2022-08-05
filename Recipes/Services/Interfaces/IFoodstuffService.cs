using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services.Interfaces
{
    public interface IFoodstuffService
    {
        public Foodstuff GetFoodstuff(int id);
        public List<Foodstuff> GetAllFoodstuffs();
        public void DeleteFoodstuff(int id);
        public void AddFoodstuff(Foodstuff foodstuff);
        public void UpdateFoodstuff(Foodstuff foodstuff);
    }
}
