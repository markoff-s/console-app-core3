using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleAppCore3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://long2know.com/2018/02/net-core-console-app-dependency-injection-and-user-secrets/
            // https://blog.bitscry.com/2017/05/31/logging-in-net-core-console-applications/
            // https://pioneercode.com/post/dependency-injection-logging-and-configuration-in-a-dot-net-core-console-app

            // Create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add logging
            serviceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
//                loggingBuilder.AddSerilog();
                loggingBuilder.AddDebug();
            });

            // add services
            //            serviceCollection.AddTransient<ITestService, TestService>();

            // build configuration
            /*var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();
            serviceCollection.AddOptions();
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));*/

            // add app
            serviceCollection.AddSingleton<App>();
        }
    }
}
