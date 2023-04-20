using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class SpecificsCollection : ObservableCollection<Specifics>
    {
        public void CopyFrom(IEnumerable<Specifics> specifics)
        {
            this.Items.Clear();
            foreach (var p in specifics)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
