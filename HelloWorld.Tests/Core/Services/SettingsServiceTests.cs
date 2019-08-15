using System;
using HelloWorld.Common;
using HelloWorld.Common.Interfaces;
using HelloWorld.Core.Services;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;

namespace HelloWorld.Tests.Core.Services
{
    public class SettingsServiceTests
    {
        private readonly IConfiguration _config = Substitute.For<IConfiguration>();
        private readonly ISettingsService _settingsService;

        public SettingsServiceTests()
        {
            _settingsService = new SettingsService(_config);
        }

        [Fact]
        public void MustThrowForMissingSection()
        {
            _config.GetSection("AppSettings").Returns((IConfigurationSection)null);

            Assert.Throws<ArgumentNullException>(() => _settingsService.Provider);
        }

        [Fact]
        public void MustThrowForMissingProviderValue()
        {
            IConfigurationSection section = Substitute.For<IConfigurationSection>();
            _config.GetSection("AppSettings").Returns(section);
            section["Provider"].Returns(string.Empty);

            Assert.Throws<ArgumentException>(() => _settingsService.Provider);
        }

        [Fact]
        public void ShouldReturnValidValueForProvider()
        {
            IConfigurationSection section = Substitute.For<IConfigurationSection>();
            _config.GetSection("AppSettings").Returns(section);
            section["Provider"].Returns("Console");

            Assert.Equal(HelloWorldProvider.Console, _settingsService.Provider);
        }

        [Fact]
        public void MustThrowForMissingOutputStringValue()
        {
            IConfigurationSection section = Substitute.For<IConfigurationSection>();
            _config.GetSection("AppSettings").Returns(section);
            section["OutputString"].Returns(string.Empty);

            Assert.Throws<ArgumentException>(() => _settingsService.OutputString);
        }

        [Fact]
        public void ShouldReturnValidValueForOutputString()
        {
            string result = "test";
            IConfigurationSection section = Substitute.For<IConfigurationSection>();
            _config.GetSection("AppSettings").Returns(section);
            section["OutputString"].Returns(result);

            Assert.Equal(result, _settingsService.OutputString);
        }
    }
}
