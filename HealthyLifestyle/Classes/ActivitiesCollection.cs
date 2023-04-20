using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class ActivitiesCollection : ObservableCollection<Activities>
    {
        public void CopyFrom(IEnumerable<Activities> activities)
        {
            this.Items.Clear();
            foreach (var p in activities)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
