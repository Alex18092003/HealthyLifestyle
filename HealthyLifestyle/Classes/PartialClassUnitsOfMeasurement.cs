using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public partial class IngredientForRecipe
    {
        public string Units
        {
            get
            {
                if (UnitsOfMeasurementId != null)
                {
                    return UnitsOfMeasurement.Title;
                }
                else
                {
                    return "По вкусу";
                }
           
            }
        }
    }
}
