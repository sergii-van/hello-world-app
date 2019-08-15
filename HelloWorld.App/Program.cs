using HelloWorld.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWorld.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ContainerConfig.Configure();

            var provider = serviceProvider.GetService<IHelloWorldProvider>();

            provider.WriteHelloWorld();
        }
    }
}
