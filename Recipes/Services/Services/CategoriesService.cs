using Recipes.Models;
using Recipes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Services.Services
{
    public class CategoriesService : ICategoriesService
    {
        private PraksaDBContext praksaDBContext;
        public CategoriesService(PraksaDBContext praksaDBContext)
        {
            this.praksaDBContext = praksaDBContext;
        }

        public Category GetCategory(int id)
        {
            return praksaDBContext.Categories.Find(id);
        }

        public List<Category> GetAllCategories()
        {
            return praksaDBContext.Categories.ToList();
        }

        public void DeleteCategory(int id)
        {
            praksaDBContext.Categories.Remove(GetCategory(id));
            praksaDBContext.SaveChanges();
        }

        public void AddCategory(Category category)
        {
            praksaDBContext.Categories.Add(category);
            praksaDBContext.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            praksaDBContext.Categories.Update(category);
            praksaDBContext.SaveChanges();
        }
    }
}