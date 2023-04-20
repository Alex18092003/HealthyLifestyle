using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class GendersCollection : ObservableCollection<Genders>
    {
        public void CopyFrom(IEnumerable<Genders> genders)
        {
            this.Items.Clear();
            foreach (var p in genders)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
