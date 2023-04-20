using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Activities
    {
        public int ActivityId { get; set; }
        public string Title { get; set; }
        public double Coefficient { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
