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

    public partial class SignUp : UserControl
    {
        public static readonly DependencyProperty SignUpCommandProperty =
            DependencyProperty.Register("SignUpCommand", typeof(ICommand), typeof(SignUp), new PropertyMetadata(null));

        public ICommand SignUpCommand
        {
            get { return (ICommand)GetValue(SignUpCommandProperty); }
            set { SetValue(SignUpCommandProperty, value); }
        }

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            if (SignUpCommand != null)
            {
                string email = tbEmail.Text;
                string username = tbUsername.Text;
                string password = pbPassword.Password;

                object[] payload = new object[] { email, username, password };
                SignUpCommand.Execute(payload);
            }
        }
    }

}