using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeTitle { get; set; }
        public string ImageUrl { get; set; }
        public string RecipeIngredients { get; set; }
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
