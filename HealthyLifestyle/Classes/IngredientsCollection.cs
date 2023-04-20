using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class IngredientsCollection : ObservableCollection<Ingredients>
    {
        public void CopyFrom(IEnumerable<Ingredients> ingredients)
        {
            this.Items.Clear();
            foreach (var p in ingredients)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
