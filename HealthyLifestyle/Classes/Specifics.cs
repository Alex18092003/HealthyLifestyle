using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Specifics
    {
        public int SpecificityId { get; set; }
        public string Title { get; set; }

     
        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
