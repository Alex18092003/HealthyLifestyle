using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class DailyRationCollection : ObservableCollection<DailyRation>
    {
        public void CopyFrom(IEnumerable<DailyRation> dailyRations)
        {
            this.Items.Clear();
            foreach (var p in dailyRations)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
