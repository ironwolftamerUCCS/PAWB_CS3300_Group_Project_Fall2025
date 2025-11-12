using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.Models
{
    public class ObservableObjects : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //Tells UI that property has changed
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
