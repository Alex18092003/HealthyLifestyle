using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class IngredientForRecipe
    {
        public int IngredientForRecipeId { get; set; }
        public int IngredientId { get; set; }
        public int RecipeId { get; set; }
        public Nullable<int> UnitsOfMeasurementId { get; set; }

        public virtual Ingredients Ingredients { get; set; }
        public virtual Recipes Recipes { get; set; }
        public virtual UnitsOfMeasurement UnitsOfMeasurement { get; set; }
    }
}
