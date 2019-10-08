using System;
using Microsoft.Extensions.Logging;

namespace ConsoleAppCore3
{
    public class App
    {
        private readonly ILogger<App> _logger;

        public App(ILogger<App> logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.LogInformation("hehe");

            Console.ReadKey();
        }
    }
}