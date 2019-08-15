using HelloWorld.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ContainerConfig.Configure();

            var factory = serviceProvider.GetService<IHelloWorldFactory>();
            var settings = serviceProvider.GetService<ISettingsService>();

            var provider = factory.GetProvider(settings.Provider);

            provider.WriteHelloWorld();
        }
    }
}
