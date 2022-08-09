using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class Storage
    {
        public int StorageId { get; set; }
        public int? FoodstuffId { get; set; }
        public decimal Quantity { get; set; }
        public decimal MinQuantity { get; set; }
        public bool? UnderMin { get; set; }

        public virtual Foodstuff Foodstuff { get; set; }
    }
}
