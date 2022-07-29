using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Recipe
    {
        public int recipeId { get; set; }
        public string recipeTitle { get; set; }
        public string imageUrl { get; set; }
        public string recipeIngredients { get; set; }
    }
}