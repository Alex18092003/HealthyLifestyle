using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Goals
    {
        public int GoalId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
