using FNVCG.COMMON;
using FNVCG.COMMON.Interfaces;
using FNVCG.MODEL;
using FNVCG.MODEL.Interfaces;
using FNVCG.VIEW.Shell;
using FNVCG.VIEWMODEL;
using FNVCG.VIEWMODEL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FNVCG.VIEW
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            // Configure Dependency Injection
            var serviceProvider = ConfigureServices();

            Shell_View shell = serviceProvider.GetRequiredService<Shell_View>();
            shell.Show();
            base.OnStartup(e);
        }

        private ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            //Register Model Factory
            services.AddScoped<IModelFactory, ModelFactory>();
            //Register ViewModel Factory
            services.AddScoped<IViewModelFactory, ViewModelFactory>();
            services.AddTransient<IConsole_VM, Console_VM>();
            //Register Views
            services.AddTransient<Shell_View>();
            services.AddTransient<Guess_View>();
            services.AddTransient<Console_View>();
            services.AddTransient<Input_View>();

            //Register event aggregator
            services.AddSingleton<IEventAggregator, EventAggregator>();



            return services.BuildServiceProvider();
        }
    }
}

        
