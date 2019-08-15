using System;
using HelloWorld.Common.Interfaces;
using HelloWorld.Core.Console.Services;
using HelloWorld.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld.App
{
    public static class ContainerConfig
    {
        public static IConfiguration Configuration { get; private set; }

        public static IServiceProvider Configure()
        {
            IConfiguration builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
            Configuration = builder;

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient(x => Configuration);
            serviceCollection.AddTransient<ISettingsService, SettingsService>();
            serviceCollection.AddTransient<IHelloWorldProvider, ConsoleProvider>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
