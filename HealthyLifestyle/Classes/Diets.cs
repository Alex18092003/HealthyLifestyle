using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Diets
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diets()
        {
            this.Recipes = new ObservableCollection<Recipes>();
        }

        public int DietId { get; set; }
        public string Title { get; set; }

       
        public virtual ICollection<Recipes> Recipes { get; set; }
    }
}
