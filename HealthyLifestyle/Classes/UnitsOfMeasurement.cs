using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class UnitsOfMeasurement
    {
        public int UnitsOfMeasurementId { get; set; }
        public string Title { get; set; }

       
        public virtual ICollection<IngredientForRecipe> IngredientForRecipe { get; set; }
    }
}
