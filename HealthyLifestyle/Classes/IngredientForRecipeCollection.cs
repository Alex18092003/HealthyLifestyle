using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class IngredientForRecipeCollection : ObservableCollection<IngredientForRecipe>
    {
        public void CopyFrom(IEnumerable<IngredientForRecipe> ingredientForRecipes)
        {
            this.Items.Clear();
            foreach (var p in ingredientForRecipes)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
