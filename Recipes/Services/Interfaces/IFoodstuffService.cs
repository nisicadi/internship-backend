using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services.Interfaces
{
    public interface IFoodstuffService
    {
        public Foodstuff GetFoodstuff(int id);
        public List<Foodstuff> GetAllFoodstuffs();
        public void DeleteFoodstuff(int id);
        public void AddFoodstuff(Newtonsoft.Json.Linq.JObject data);
        public void UpdateFoodstuff(Foodstuff foodstuff);
    }
}
