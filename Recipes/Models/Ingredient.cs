using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.Models
{
    public partial class Ingredient
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }
        public decimal? Quantity { get; set; }
        public int? RecipeId { get; set; }
        public int? FoodstuffId { get; set; }

        public virtual Foodstuff Foodstuff { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
