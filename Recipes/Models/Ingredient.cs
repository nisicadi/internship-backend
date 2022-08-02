using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Ingredient
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public decimal? Quantity { get; set; }
        public int? RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
