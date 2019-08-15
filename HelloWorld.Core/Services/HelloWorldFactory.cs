using System;
using HelloWorld.Common;
using HelloWorld.Common.Interfaces;

namespace HelloWorld.Core.Services
{
    public class HelloWorldFactory : IHelloWorldFactory
    {
        private readonly ISettingsService _settings;

        public HelloWorldFactory(ISettingsService settings)
        {
            _settings = settings;
        }

        public IHelloWorldProvider GetProvider(HelloWorldProvider provider)
        {
            switch (provider)
            {
                case HelloWorldProvider.Console:
                    return new ConsoleProvider(_settings);

                case HelloWorldProvider.Database:
                    throw new NotImplementedException();

                default:
                    throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
            }
        }
    }
}
