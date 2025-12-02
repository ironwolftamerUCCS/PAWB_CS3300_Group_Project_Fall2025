using PAWB.Domain.Model;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
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
        public string NewEntryEmail { get; set; }
        public string NewEntryUsername { get; set; }
        public string NewEntryPassword { get; set; }
        public string NewEntryNotes { get; set; }


        // Owner ID to associate the new entry with
        private readonly int _ownerId;
        public AddEntry(int ownerId)
        {
            InitializeComponent();
            _ownerId = ownerId;
        }
        public AddEntry() : this(0) // Default ownerId to 0 if not provided 
        {
        }
        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewEntryAccount = AccountTextBox.Text;
            NewEntryEmail = EmailTextBox.Text;
            NewEntryUsername = UsernameTextBox.Text;
            NewEntryPassword = PasswordTextBox.Text;
            NewEntryNotes = NotesTextBox.Text;

            (sender as Button).IsEnabled = false;

            try
            {
                var dbFactory = new PAWBDbContextFactory();
                var userService = new GenericDataService<User>(dbFactory);
                var entryService = new GenericDataService<Entry>(dbFactory);

                // load owner user from DB to set the owner id (no cross-context entity attachment)
                var owner = await userService.Get(_ownerId);
                if (owner == null)
                {
                    MessageBox.Show("Specified owner was not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    (sender as Button).IsEnabled = true;
                    return;
                }

                var newEntry = new Entry
                {
                    Title = NewEntryAccount,
                    Username = NewEntryUsername,
                    Password = NewEntryPassword, // for real apps encrypt/secure this value
                    Email = string.IsNullOrWhiteSpace(NewEntryEmail) ? owner.Email : NewEntryEmail,
                    // set the FK directly instead of assigning the tracked User instance
                    OwnerId = owner.Id,
                    Owner = null, // avoid passing a user instance from a different DbContext
                    Note = string.IsNullOrWhiteSpace(NewEntryNotes) ? null : NewEntryNotes,
                    LastUpdated = DateTime.UtcNow,
                    PasswordLastUpdated = DateTime.UtcNow,
                    PreviousPasswords = null
                };

                await entryService.Create(newEntry);

                MessageBox.Show("Entry added.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to add entry: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                (sender as Button).IsEnabled = true;
            }
        }


        private void CancelButton_Click(Object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
