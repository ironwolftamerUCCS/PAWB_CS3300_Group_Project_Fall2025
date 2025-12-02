using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.ViewModels
{
    /// <summary>
    /// Initializes an error message
    /// </summary>
    public class MessageViewModel : ViewModelBase
    {
        // Vars
        private string _message;
        public string Message
        {
            get { return _message; }  
            set 
            { 
                _message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(HasMessage));
            }
        }

        public bool HasMessage => !string.IsNullOrEmpty(_message);
    }
}
