using System;
using System.Windows;
using Hotel.ViewModels;
using HS.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HS
{
    public partial class App : Application
    {
        private static IHost _host;
        public static IHost Host => _host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
        public static IServiceProvider Services => Host.Services;

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddViewModels()
        ;

        protected override async void OnStartup(StartupEventArgs e)
        {
            using var scope = Services.CreateScope();
            await scope.ServiceProvider.GetRequiredService<DbInitializer>().Initialize();
            
            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}