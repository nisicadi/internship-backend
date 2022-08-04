using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Foodstuff
    {
        public Foodstuff()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        public int FoodstuffId { get; set; }
        public string FoodstuffName { get; set; }
        public int? MeasurementId { get; set; }

        public virtual MeasurementUnit Measurement { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
