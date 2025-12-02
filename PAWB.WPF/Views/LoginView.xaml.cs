using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PAWB.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        // Vars
        public static readonly DependencyProperty LoginCommandProperty =
            DependencyProperty.Register("LoginCommand", typeof(ICommand), typeof(LoginView), new PropertyMetadata(null));
       
        public ICommand LoginCommand
        {
            get { return (ICommand)GetValue(LoginCommandProperty); }
            set { SetValue(LoginCommandProperty, value); }
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles log in button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(LoginCommand != null)
            {
                string password = pbPassword.Password;
                LoginCommand.Execute(password);
            }
            
        }
        
        /// <summary>
        /// Navigate to SignUp view when "Sign-up here" is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpPage_Click(object sender, RoutedEventArgs e)
        {
            // Use MainViewModel's command 
            var mainVm = Application.Current?.MainWindow?.DataContext as MainViewModel;
            mainVm.UpdateCurrentViewModelCommand.Execute(ViewType.SignUp);
            return;
            
        }
    }
}
