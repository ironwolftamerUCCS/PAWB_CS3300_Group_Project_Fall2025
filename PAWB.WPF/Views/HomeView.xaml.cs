using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using PAWB.Domain.Model;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using PAWB.WPF.Models;
using PAWB.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
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

        private Cursor Grey;
        private Cursor Brown;   
        private Cursor WhiteGrey;
        private Cursor TriGrey;
        public HomeView()
        {
            // Custom Cursor
            Grey = new Cursor(Application.GetResourceStream(new Uri("Cursors/pawcursordefault.cur", UriKind.Relative)).Stream);
            Brown = new Cursor(Application.GetResourceStream(new Uri("Cursors/browncursorpaw.cur", UriKind.Relative)).Stream);
            WhiteGrey = new Cursor(Application.GetResourceStream(new Uri("Cursors/whitegreycursorpaw.cur", UriKind.Relative)).Stream);
            TriGrey = new Cursor(Application.GetResourceStream(new Uri("Cursors/greywhitecursorpaw.cur", UriKind.Relative)).Stream);

            InitializeComponent();

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

        //Add entry button
        private void OpenAddEntryPopup_Click(object sender, RoutedEventArgs e)
        {
            // Resolve the authenticator from the app service provider
            if (App.ServiceProvider == null)
            {
                MessageBox.Show("Service provider not available.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var authenticator = App.ServiceProvider.GetRequiredService<IAuthenticator>();
            int ownerId = authenticator?.CurrentAccount?.AccountHolder?.Id ?? 0;

            if (ownerId == 0)
            {
                MessageBox.Show("No logged-in user found. Please log in before adding an entry.", "Not logged in", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Pass the valid owner id to the AddEntry window
            AddEntry addEntry = new AddEntry(ownerId);
            bool? result = addEntry.ShowDialog();

            if (result == true)
            {
                string newAccountEntry = addEntry.NewEntryAccount;
                string newEmailEntry = addEntry.NewEntryEmail;
                string newUsernameEntry = addEntry.NewEntryUsername;
                string newPasswordEntry = addEntry.NewEntryPassword;
                string newNotesEntry = addEntry.NewEntryNotes;
                // Add newEntry to data source here
                //Items.Add(newAccountEntry); ??????????
                MessageBox.Show($"New entry added: {newAccountEntry}");
                
            }

        }

        private void OpenLoginScreen_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LoginView());
            
        }
        
    }
}
