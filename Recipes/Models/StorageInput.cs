using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class StorageInput
    {
        public int StorageInputId { get; set; }
        public int? FoodstuffId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime InputDate { get; set; }
        public bool RemoveQuantity { get; set; }

        public virtual Foodstuff Foodstuff { get; set; }
    }
}
