using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodstuffController : Controller
    {
        private readonly IFoodstuffService _foodstuffInterface;
        public FoodstuffController(IFoodstuffService foodstuffInterface)
        {
            _foodstuffInterface = foodstuffInterface;
        }

        //Categories
        [HttpGet]
        public List<Foodstuff> GetAllCategories()
        {
            return _foodstuffInterface.GetAllFoodstuffs();
        }

        [HttpGet("{id}")]
        public Foodstuff GetFoodstuffById(int id)
        {
            return _foodstuffInterface.GetFoodstuff(id);
        }

        [HttpDelete("{id}")]
        public void DeleteFoodstuff(int id)
        {
            _foodstuffInterface.DeleteFoodstuff(id);
        }

        [HttpPost]
        public void AddFoodstuff(Newtonsoft.Json.Linq.JObject data)
        {
            _foodstuffInterface.AddFoodstuff(data);
        }

        [HttpPut("{id}")]
        public void UpdateFoodstuff(Foodstuff foodstuff)
        {
            _foodstuffInterface.UpdateFoodstuff(foodstuff);
        }
    }
}
