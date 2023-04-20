using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    class DietsCollection : ObservableCollection<Diets>
    {
        public void CopyFrom(IEnumerable<Diets> diets)
        {
            this.Items.Clear();
            foreach (var p in diets)
            {
                this.Items.Add(p);
            }

            this.OnCollectionChanged(
                new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
