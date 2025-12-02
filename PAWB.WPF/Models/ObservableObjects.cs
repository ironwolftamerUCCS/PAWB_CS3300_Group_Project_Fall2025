using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.Models
{
    /// <summary>
    /// Defines intermediary function between changed properties and corresponding UI changes
    /// </summary>
    public class ObservableObjects : INotifyPropertyChanged
    {
        // Vars
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Tells UI that property has changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
