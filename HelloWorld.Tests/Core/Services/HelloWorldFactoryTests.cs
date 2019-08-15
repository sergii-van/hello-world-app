using System;
using HelloWorld.Common;
using HelloWorld.Common.Interfaces;
using HelloWorld.Core.Services;
using NSubstitute;
using Xunit;

namespace HelloWorld.Tests.Core.Services
{
    public class HelloWorldFactoryTests
    {
        private readonly IHelloWorldFactory _factory;

        public HelloWorldFactoryTests()
        {
            var settingsService = Substitute.For<ISettingsService>();
            _factory = new HelloWorldFactory(settingsService);
        }

        [Fact]
        public void CanGetConsoleProvider()
        {
            var result = _factory.GetProvider(HelloWorldProvider.Console);

            Assert.IsType<ConsoleProvider>(result);
        }

        [Fact]
        public void MustThrowForNotImplementedProviders()
        {
            Assert.Throws<NotImplementedException>(() => _factory.GetProvider(HelloWorldProvider.Database));
        }

        [Fact]
        public void MustThrowForInvalidProviders()
        {
            var provider = (HelloWorldProvider)123;

            Assert.Throws<ArgumentOutOfRangeException>(() => _factory.GetProvider(provider));
        }
    }
}
