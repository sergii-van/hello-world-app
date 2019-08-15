using System;
using HelloWorld.Common.Interfaces;
using HelloWorld.Core.Helpers;
using HelloWorld.Core.Services;
using NSubstitute;
using Xunit;

namespace HelloWorld.Tests.Core.Services
{
    public class ConsoleProviderTests : IDisposable
    {
        private readonly ConsoleProvider _provider;
        private readonly ISettingsService _settingsService = Substitute.For<ISettingsService>();

        public ConsoleProviderTests()
        {
            _provider = new ConsoleProvider(_settingsService);
        }

        [Fact]
        public void MustPrintConsoleLog()
        {
            string msg = "test";
            int counter = 0;
            _settingsService.OutputString.Returns(msg);
            ConsoleWrapper.WriteLineDelegate = message =>
            {
                if (msg.Equals(message))
                {
                    counter++;
                }
            };

            _provider.WriteHelloWorld();

            Assert.Equal(1, counter);
        }

        public void Dispose()
        {
            ConsoleWrapper.ResetDelegates();
        }
    }
}
