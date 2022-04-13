using Microsoft.Extensions.Configuration;

namespace Automation.Core
{
    public class Configuration
    {
        private static IConfigurationRoot _config;

        static Configuration()
        {
            _config = InitTestConfigs();
        }

        private static IConfigurationRoot InitTestConfigs()
        {
            return new ConfigurationBuilder().
                SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public static string BaseUrl => _config["BaseUrl"];
    }
}
