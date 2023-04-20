using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class RecipesCollection : ObservableCollection<Recipes>
    {
        public void CopyFrom(IEnumerable<Recipes> recipes)
        {
            this.Items.Clear();
            foreach (var p in recipes)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
