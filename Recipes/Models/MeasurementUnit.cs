using System;
using System.Collections.Generic;

#nullable disable

namespace Recipes.Models
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            Foodstuffs = new HashSet<Foodstuff>();
        }

        public int MeasurementId { get; set; }
        public string Measurement { get; set; }
        public string MeasurementLong { get; set; }

        public virtual ICollection<Foodstuff> Foodstuffs { get; set; }
    }
}
