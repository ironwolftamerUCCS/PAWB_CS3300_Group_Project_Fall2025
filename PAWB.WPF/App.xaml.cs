using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using PAWB.Domain.Models;
using PAWB.Domain.Services;
using PAWB.Domain.Services.AuthenticationServices;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using PAWB.WPF.State.Authenticators;
using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels;
using PAWB.WPF.ViewModels.Factories;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PAWB.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceScope _appScope;
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            //Create a scope and keep it for app lifetime
            _appScope = serviceProvider.CreateScope();

            //Resolve authenticator from the scope and create LoginViewModel
            var authenticator = _appScope.ServiceProvider.GetRequiredService<IAuthenticator>();
            var loginViewModel = new LoginViewModel(authenticator);

            //Creating main window and setting datacontext to login veiw model, need to generalize this
            //So that the datacontext can be changed based on navigation
            Window window = new MainWindow(loginViewModel);
            
            window.Show();

            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<PAWBDbContextFactory>();
            services.AddSingleton<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IAccountService, AccountDataService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<IPAWBViewModelFactory, PAWBViewModelFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();

            //Need to go back and figure out MainWindow.cs functions
            //services.AddScoped<MainWindow>(services => new MainWindow(s.GetRequiredService<MainViewModel>())) >;

            return services.BuildServiceProvider();
            
        }

    }

}
