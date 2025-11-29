using PAWB.Domain.Model;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using PAWB.WPF.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;

namespace PAWB.WPF.ViewModels
{
    public class SignUpModel : ViewModelBase
    {
        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                _statusMessage = value;
                OnPropertyChanged(nameof(StatusMessage));
            }
        }

        public ICommand SignUpCommand { get; }

        public SignUpModel()
        {
            // Simple command that expects the SignUp UserControl to call with object[] { email, username, password }
            SignUpCommand = new DelegateCommand(ExecuteSignUpAsync);
        }

        private async Task ExecuteSignUpAsync(object parameter)
        {
            try
            {
                StatusMessage = string.Empty;

                if (parameter is not object[] payload || payload.Length < 3)
                {
                    StatusMessage = "Invalid signup payload.";
                    return;
                }

                string email = payload[0] as string ?? string.Empty;
                string username = payload[1] as string ?? string.Empty;
                string password = payload[2] as string ?? string.Empty;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    StatusMessage = "All fields are required.";
                    return;
                }

                var factory = new PAWBDbContextFactory();
                var userService = new GenericDataService<User>(factory);

                var newUser = new User
                {
                    Username = username,
                    Email = email,
                    // Store the password as-is (no hashing). It's stored in PasswordHash field.
                    PasswordHash = password,
                    DateJoined = DateTime.UtcNow
                };

                var created = await userService.Create(newUser);

                // Verify insert and report a concise status
                using var ctx = factory.CreateDbContext();
                var userCount = await ctx.Users.CountAsync();

                StatusMessage = $"Account created (Id={created.Id}). Users in DB: {userCount}.";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create account: {ex.GetType().Name}: {ex.Message}";
            }
        }
    }
}
