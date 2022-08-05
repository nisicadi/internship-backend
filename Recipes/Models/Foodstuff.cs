using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Recipes.Models
{
    public partial class Foodstuff
    {
        public Foodstuff()
        {
            Ingredients = new HashSet<Ingredient>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FoodstuffId { get; set; }
        public string FoodstuffName { get; set; }
        public int? MeasurementId { get; set; }

        public virtual MeasurementUnit Measurement { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
