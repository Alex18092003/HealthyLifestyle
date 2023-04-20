using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class KitchensCollection : ObservableCollection<Kitchens>
    {
        public void CopyFrom(IEnumerable<Kitchens> kitchens)
        {
            this.Items.Clear();
            foreach (var p in kitchens)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
