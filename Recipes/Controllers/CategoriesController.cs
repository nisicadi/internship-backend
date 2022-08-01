using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;

namespace Recipes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesInterface;
        public CategoriesController(ICategoriesService categoriesInterface)
        {
            _categoriesInterface = categoriesInterface;
        }

        //Categories
        [HttpGet]
        public List<Category> GetAllCategories()
        {
            return _categoriesInterface.GetAllCategories();
        }

        [HttpGet("{id}")]
        public Category GetCategoryById(int id)
        {
            return _categoriesInterface.GetCategory(id);
        }

        [HttpDelete("{id}")]
        public void DeleteCategory(int id)
        {
            _categoriesInterface.DeleteCategory(id);
        }

        [HttpPost]
        public void AddCategory(Category category)
        {
            _categoriesInterface.AddCategory(category);
        }

        [HttpPut("{id}")]
        public void UpdateCategory(Category category)
        {
            _categoriesInterface.UpdateCategory(category);
        }
    }
}
