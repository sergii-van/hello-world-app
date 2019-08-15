using HelloWorld.Common.Interfaces;
using HelloWorld.Core.Console.Helpers;

namespace HelloWorld.Core.Console.Services
{
    public class ConsoleProvider : IHelloWorldProvider
    {
        private readonly ISettingsService _settings;

        public ConsoleProvider(ISettingsService settings)
        {
            _settings = settings;
        }

        public void WriteHelloWorld()
        {
            ConsoleWrapper.WriteLine(_settings.OutputString);
        }
    }
}
