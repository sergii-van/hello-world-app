using System;
using HelloWorld.Common;
using HelloWorld.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace HelloWorld.Core.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly IConfiguration _configuration;

        public SettingsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public HelloWorldProvider Provider
        {
            get
            {
                var section = GetSection("AppSettings");
                string paramValue = section["Provider"];
                if (!Enum.TryParse(paramValue, out HelloWorldProvider provider))
                {
                    throw new ArgumentException($"Provider value is not correct: {paramValue}", "Provider");
                }

                return provider;
            }
        }

        public string OutputString
        {
            get
            {
                var section = GetSection("AppSettings");
                string paramValue = section["OutputString"];
                if (string.IsNullOrWhiteSpace(paramValue))
                {
                    throw new ArgumentException($"String value is not defined or empty: {paramValue}", "OutputString");
                }

                return paramValue;
            }
        }

        private IConfigurationSection GetSection(string name)
        {
            var section = _configuration.GetSection(name);
            if (section == null)
            {
                throw new ArgumentNullException(name, $"Section is not defined: {name}");
            }

            return section;
        }
    }
}
