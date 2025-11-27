using PAWB.WPF.Models;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        private bool _isDefaultTheme = true;

        public List<InfoItem> Items { get; set; }

        public HomeView()
        {
            InitializeComponent();
            //DataContext = dataContext;

            // For list view
            Items = new List<InfoItem>()
            {
                new InfoItem { Title = "Account 1", Description = "Description1"},
                new InfoItem { Title = "Account 2", Description = "Description2"},
                new InfoItem { Title = "Account 3", Description = "Description3"},
            };
            DataContext = this;

        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            Button btn = sender as Button;
            InfoItem item = btn.DataContext as InfoItem;

            DetailWindow window = new DetailWindow(item);
            window.ShowDialog();
            */

            var item = (sender as FrameworkElement)?.DataContext as InfoItem;
            if (item != null)
            {
                var win = new DetailWindow(item);
                win.ShowDialog();
            }

        }

        private void OnToggleButtonChecked(object sender, RoutedEventArgs e)
        {
            _isDefaultTheme = !_isDefaultTheme;
            string newThemePath = _isDefaultTheme ? "Themes/Default.xaml" : "Themes/ScaryPawble.xaml";
            var newTheme = (ResourceDictionary)Application.LoadComponent(new Uri(newThemePath, UriKind.Relative));
            Application.Current.Resources.MergedDictionaries.RemoveAt(0);
            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

}
}
