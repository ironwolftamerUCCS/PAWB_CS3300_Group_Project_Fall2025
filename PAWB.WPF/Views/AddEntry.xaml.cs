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
using System.Windows.Shapes;

namespace PAWB.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddEntry.xaml
    /// </summary>
    public partial class AddEntry : Window
    {

        public string NewEntryAccount { get; set; }
        public string NewEntryUsername { get; set; }
        public string NewEntryPassword { get; set; }

        public AddEntry()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewEntryAccount = AccountTextBox.Text;
            NewEntryUsername = UsernameTextBox.Text;
            NewEntryPassword = PasswordTextBox.Text;


            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(Object sender, RoutedEventArgs e)
        { 
            DialogResult = false; 
            Close();
        }
    }
}
