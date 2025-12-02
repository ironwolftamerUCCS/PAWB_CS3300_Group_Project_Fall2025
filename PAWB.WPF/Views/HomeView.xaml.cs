using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using PAWB.Domain.Model;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using PAWB.WPF.Models;
using PAWB.WPF.State.Authenticators;
using PAWB.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        // Vars
        private bool _isDefaultTheme = true;

        public List<InfoItem> Items { get; set; } = new List<InfoItem>();

        private Cursor Grey;
        private Cursor Brown;   
        private Cursor WhiteGrey;
        private Cursor TriGrey;

        /// <summary>
        /// Constructor
        /// </summary>
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

        /// <summary>
        /// Loads the entries for the logged in user and populates them in the view
        /// </summary>
        /// <returns></returns>
        private async Task LoadEntrysAsync()
        {
            try
            {
                // Find the logged-in user's username via MainViewModel -> Authenticator -> CurrentAccount
                var mainVm = Application.Current?.MainWindow?.DataContext as MainViewModel;
                var currentAccount = mainVm?.Authenticator?.CurrentAccount;
                if (currentAccount == null || currentAccount.AccountHolder == null)
                {
                    // Not logged in — clear items and return
                    await Application.Current.Dispatcher.InvokeAsync(() => Items.Clear());
                    return;
                }

                string username = currentAccount.AccountHolder.Username;

                var factory = new PAWBDbContextFactory();
                using var ctx = factory.CreateDbContext();

                // Project only needed fields. Filter by owner username to return only entries for the logged-in user.
                var results = await ctx.Entrys
                    .AsNoTracking()
                    .Where(e => e.Owner != null && e.Owner.Username == username)
                    .Select(e => new InfoItem
                    {
                        Title = e.Title,
                        Email = e.Email,
                        Username = e.Username,
                        Password = e.Password,
                        Description = e.Note, // change to e.Email or e.Note if desired
                        

                    })
                    .ToListAsync();

                await Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Items.Clear();
                    foreach (var it in results)
                    {
                        Items.Add(it);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load entries: {ex.Message}", "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Handles interaction for detail button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement)?.DataContext as InfoItem;
            if (item != null)
            {
                var win = new DetailWindow(item);
                win.ShowDialog();
            }
        }

        /// <summary>
        /// Handles interaction with dark mode toggle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                LoadEntrysAsync();
                
            }

        }

        private void OpenLoginScreen_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new LoginView());
            
        }

    }
}
