using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class DailyRation
    {
        public int DailyRationId { get; set; }
        public int UserId { get; set; }
        public int RecepeId { get; set; }
        public System.DateTime Date { get; set; }

        public virtual Recipes Recipes { get; set; }
        public virtual Users Users { get; set; }
    }
}
