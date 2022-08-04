using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public decimal? RecipePrice { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
