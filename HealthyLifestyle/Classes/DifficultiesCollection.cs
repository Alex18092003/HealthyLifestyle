using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class DifficultiesCollection : ObservableCollection<Difficulties>
    {
        public void CopyFrom(IEnumerable<Difficulties> difficulties)
        {
            this.Items.Clear();
            foreach (var p in difficulties)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
