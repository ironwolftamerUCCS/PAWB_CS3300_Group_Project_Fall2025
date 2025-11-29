using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PAWB.Domain.Model;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using PAWB.WPF.Models;
using PAWB.WPF.Views;
using System;
using System.Collections.Generic;
using System.IO;
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
        // Custom theme
        private bool _isDefaultTheme = true;

        // Custom cursor
        Cursor Grey, Brown, WhiteGrey, TriGrey;

        // List view on homepage
        public List<InfoItem> Items { get; set; }

        public HomeView()
        {
            InitializeComponent();

            // Custom Cursor
            //string cursorDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\Cursors";
            Grey = new Cursor(Application.GetResourceStream(new Uri("Cursors/pawcursordefault.cur", UriKind.Relative)).Stream);
            Brown = new Cursor(Application.GetResourceStream(new Uri("Cursors/browncursorpaw.cur", UriKind.Relative)).Stream);
            WhiteGrey = new Cursor(Application.GetResourceStream(new Uri("Cursors/whitegreycursorpaw.cur", UriKind.Relative)).Stream);
            TriGrey = new Cursor(Application.GetResourceStream(new Uri("Cursors/greywhitecursorpaw.cur", UriKind.Relative)).Stream);

            this.Loaded += async (_, __) => await LoadEntrysAsync();

        }

        private async Task LoadEntrysAsync()
        {
            try
            { 
                // For list view
                Items = new List<InfoItem>();
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
            }

            catch (Exception ex)
            {
                // Show a simple error - adjust logging as needed
                MessageBox.Show($"Failed to load entries: {ex.Message}", "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
}

private void DetailButton_Click(object sender, RoutedEventArgs e)
{
    var item = (sender as FrameworkElement)?.DataContext as InfoItem;
    if (item != null)
    {
        var win = new DetailWindow(item);
        win.ShowDialog();
    }

}

// Custom theme
private void OnToggleButtonChecked(object sender, RoutedEventArgs e)
{
    _isDefaultTheme = !_isDefaultTheme;
    string newThemePath = _isDefaultTheme ? "Themes/Default.xaml" : "Themes/ScaryPawble.xaml";
    var newTheme = (ResourceDictionary)Application.LoadComponent(new Uri(newThemePath, UriKind.Relative));
    Application.Current.Resources.MergedDictionaries.RemoveAt(0);
    Application.Current.Resources.MergedDictionaries.Add(newTheme);
}

// Custom Paw Cursors
private void btnGrey_Click(object sender, RoutedEventArgs e)
{
    if (sender == btnGrey)
    {
        this.Cursor = Grey;
    }
    else if (sender == btnBrown)
    {
        this.Cursor = Brown;
    }
    else if (sender == btnWhiteGrey)
    {
        this.Cursor = WhiteGrey;
    }
    else if (sender == btnTriGrey)
    {
        this.Cursor = TriGrey;
    }
}

private void btnBrown_Click(object sender, RoutedEventArgs e)
{
    if (sender == btnGrey)
    {
        this.Cursor = Grey;
    }
    else if (sender == btnBrown)
    {
        this.Cursor = Brown;
    }
    else if (sender == btnWhiteGrey)
    {
        this.Cursor = WhiteGrey;
    }
    else if (sender == btnTriGrey)
    {
        this.Cursor = TriGrey;
    }
}

private void btnWhiteGrey_Click(object sender, RoutedEventArgs e)
{
    if (sender == btnGrey)
    {
        this.Cursor = Grey;
    }
    else if (sender == btnBrown)
    {
        this.Cursor = Brown;
    }
    else if (sender == btnWhiteGrey)
    {
        this.Cursor = WhiteGrey;
    }
    else if (sender == btnTriGrey)
    {
        this.Cursor = TriGrey;
    }
}

private void btnTriGrey_Click(object sender, RoutedEventArgs e)
{
    if (sender == btnGrey)
    {
        this.Cursor = Grey;
    }
    else if (sender == btnBrown)
    {
        this.Cursor = Brown;
    }
    else if (sender == btnWhiteGrey)
    {
        this.Cursor = WhiteGrey;
    }
    else if (sender == btnTriGrey)
    {
        this.Cursor = TriGrey;
    }
}

    }
}