using Check.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GeneratorStref
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices((context, services) => {
                ConfigureServices(services);
            })
                .Build();
        }

        private void ConfigureServices(IServiceCollection service)
        {
            service.AddSingleton<MainWindow>();
            service.AddSingleton<ILicencja, Licencja>();
            service.AddScoped<IComputerIdentity, ComputerIdentity>();
            service.AddScoped<IRejestr, Rejestr>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);

            _host.Services.GetService<ILicencja>().Inicjacja();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host?.StopAsync();
            }

            base.OnExit(e);
        }
    }
}
