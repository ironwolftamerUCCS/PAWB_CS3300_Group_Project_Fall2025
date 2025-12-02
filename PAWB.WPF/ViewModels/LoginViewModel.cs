using PAWB.WPF.Commands;
using PAWB.WPF.State.Authenticators;
using PAWB.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.ViewModels
{
    /// <summary>
    /// Initializes  the LoginViewModel
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {
        // Vars
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
         
        public MessageViewModel ErrorMessageViewModel { get; }

        public string ErrorMessage 
        { 
            set => ErrorMessageViewModel.Message = value; 
        }

        public ICommand LoginCommand { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticator"></param>
        /// <param name="renavigator"></param>
        public LoginViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            LoginCommand = new LoginCommand(this, authenticator, renavigator);
        }
    }
}
