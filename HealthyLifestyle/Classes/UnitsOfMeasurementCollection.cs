using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class UnitsOfMeasurementCollection : ObservableCollection<UnitsOfMeasurement>
    {
        public void CopyFrom(IEnumerable<UnitsOfMeasurement> units)
        {
            this.Items.Clear();
            foreach (var p in units)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
