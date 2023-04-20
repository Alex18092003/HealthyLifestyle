using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Recipes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Recipes()
        {
            this.DailyRation = new ObservableCollection<DailyRation>();
            this.IngredientForRecipe = new ObservableCollection<IngredientForRecipe>();
            this.Steps = new ObservableCollection<Steps>();
        }

        public int RecipeId { get; set; }
        public string Title { get; set; }
        public int MinutesOfCooking { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Photo { get; set; }
        public Nullable<int> MealId { get; set; }
        public Nullable<int> RecipeType { get; set; }
        public Nullable<int> DietId { get; set; }
        public Nullable<int> SpecificsId { get; set; }
        public Nullable<int> DifficultyId { get; set; }
        public Nullable<int> CookingId { get; set; }
        public Nullable<int> KitchenId { get; set; }


       

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DailyRation> DailyRation { get; set; }
        public virtual Diets Diets { get; set; }
        public virtual Difficulties Difficulties { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IngredientForRecipe> IngredientForRecipe { get; set; }
        public virtual Kitchens Kitchens { get; set; }
        public virtual Meals Meals { get; set; }
        public virtual Preparations Preparations { get; set; }
        public virtual RecipeTypes RecipeTypes { get; set; }
        public virtual Specifics Specifics { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Steps> Steps { get; set; }
    }
}
