using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class RecipeTypesCollection : ObservableCollection<RecipeTypes>
    {
        public void CopyFrom(IEnumerable<RecipeTypes> recipeTypes)
        {
            this.Items.Clear();
            foreach (var p in recipeTypes)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

    }
}
