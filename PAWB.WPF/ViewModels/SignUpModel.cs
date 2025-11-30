using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PAWB.Domain.Model;
using PAWB.Domain.Services.AuthenticationServices;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using PAWB.WPF.Commands;
using PAWB.WPF.State.Navigators;
using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PAWB.WPF.ViewModels
{
    public class SignUpModel : ViewModelBase
    {
        private readonly IAuthenticationService _authenticationService;

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

        public SignUpModel(IAuthenticationService authenticationService)
        {
            // Simple command that expects the SignUp UserControl to call with object[] { email, username, password }

            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));

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

                // Use AuthenticationService.Resister to create the Account/User
                var result = await _authenticationService.Resister(email, username, password, password);

                switch (result)
                {
                    case RegistrationResult.Success:
                        StatusMessage = "Account created. Redirecting to login...";
                        // navigate to login using MainViewModel like before
                        var mainVm = System.Windows.Application.Current?.MainWindow?.DataContext as MainViewModel;
                        mainVm?.UpdateCurrentViewModelCommand.Execute(ViewType.Login);
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        StatusMessage = "Passwords do not match.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        StatusMessage = "Email already exists.";
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        StatusMessage = "Username already exists.";
                        break;
                    default:
                        StatusMessage = "Registration failed.";
                        break;
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to create account: {ex.GetType().Name}: {ex.Message}";
            }
        }
    }
}
