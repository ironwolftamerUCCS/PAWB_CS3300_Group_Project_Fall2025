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
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();

            //Creating main view model using the service providers
            Window window = serviceProvider.GetRequiredService<MainWindow>();
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

            // PAWBViewModelFactory now requires a CreateViewModel<SignUpModel> as well
            services.AddSingleton<IPAWBViewModelFactory, PAWBViewModelFactory>();

            // Register factory methods for each viewmodel. Services required by each viewmodel's constructor are passed.
            services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();

            services.AddSingleton<CreateViewModel<LoginViewModel>>(services =>
            {
                return () => new LoginViewModel(
                    services.GetRequiredService<IAuthenticator>(),
                    services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
            });

            services.AddSingleton<HomeViewModel>(services => new HomeViewModel());
            services.AddSingleton<CreateViewModel<HomeViewModel>>(services =>
            {
                return () => services.GetRequiredService<HomeViewModel>();
            });

            // Register SignUpModel and its CreateViewModel delegate
            services.AddSingleton<SignUpModel>(services => new SignUpModel());
            services.AddSingleton<CreateViewModel<SignUpModel>>(services =>
            {
                return () => services.GetRequiredService<SignUpModel>();
            });

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<IAuthenticator, Authenticator>();
            services.AddScoped<MainViewModel>();

            
            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
            
        }

    }

}
