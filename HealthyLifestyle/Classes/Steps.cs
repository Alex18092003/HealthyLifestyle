using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Steps
    {
        public int StepId { get; set; }
        public int RecipeId { get; set; }
        public int StepNomen { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }

        public virtual Recipes Recipes { get; set; }
    }
}
