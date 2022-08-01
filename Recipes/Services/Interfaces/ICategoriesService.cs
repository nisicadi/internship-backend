using Recipes.Models;
using System.Collections.Generic;

namespace Recipes.Services.Interfaces
{
    public interface ICategoriesService
    {
        public Category GetCategory(int id);
        public List<Category> GetAllCategories();
        public void DeleteCategory(int id);
        public void AddCategory(Category category);
        public void UpdateCategory(Category category);
    }
}
