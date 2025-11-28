using PAWB.Domain.Model;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
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

        public List<InfoItem> Items { get; set; } = new List<InfoItem>();

        public HomeView()
        {
            InitializeComponent();
            //DataContext = dataContext;

            DataContext = this;

            this.Loaded += async (_, __) => await LoadEntrysAsync();
        
        }

        private async Task LoadEntrysAsync()
        {
            try
            {
                var entrysService = new GenericDataService<User>(new PAWBDbContextFactory());
                var entrys = await entrysService.GetAll();

                // If service returned null, leave Items empty so UI displays nothing
                if (entrys == null)
                {
                    await Application.Current.Dispatcher.InvokeAsync(() => Items.Clear());
                    return;
                }

                // Update collection on UI thread
                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Items.Clear();
                    foreach (var u in entrys)
                    {
                        Items.Add(new InfoItem
                        {
                            Title = u.Username,
                            Description = u.Email
                        });
                    }
                });
            }
            catch (Exception ex)
            {
                // Show a simple error - adjust logging as needed
                MessageBox.Show($"Failed to load entries: {ex.Message}", "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
