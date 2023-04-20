using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Kitchens
    {
        public int KitchenId { get; set; }
        public string Title { get; set; }

      
        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
