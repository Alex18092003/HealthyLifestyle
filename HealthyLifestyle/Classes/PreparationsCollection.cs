using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class PreparationsCollection : ObservableCollection<Preparations>
    {
        public void CopyFrom(IEnumerable<Preparations> preparations)
        {
            this.Items.Clear();
            foreach (var p in preparations)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
