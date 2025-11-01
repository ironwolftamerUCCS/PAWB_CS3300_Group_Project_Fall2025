using PAWB.Domain.Models;
using PAWB.Domain.Services;
using PAWB.EntityFramework.Services;
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
            IDataService<Account> accountService = new AccountDataService(new EntityFramework.PAWBDbContextFactory());
            //See lower comment to implement and test IAuthenticaitonService
            //IServiceProvider serviceProvider = CreateServiceProvider();
            //IAuthenticationService authentication = serviceProvider.GetRequiredServices<IAuthenticationService>();
            //authentication.Register("test@gmail.com", "testuser", "test1234", "test1234");
            Window window = new MainWindow();
            window.Show();

            base.OnStartup(e);
        }

        //Need to implment private IserviceProvider CreateServiceProvider() to create a collection of servces to work with the database (I think?)
    }

}
