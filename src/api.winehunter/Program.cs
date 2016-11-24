using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace api.winehunter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Wine Hunter API Serivces");
            Console.WriteLine("INFORMATION");
            Console.WriteLine("This service provides the necessary api to create and catalog the users favorite wines");

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var host = new WebHostBuilder()
               
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    if (config["threadCount"] != null)
                    {
                        options.ThreadCount = int.Parse(config["threadCount"]);
                    }

                    //TODO: Enable Https
                    //options.UseHttps("","");
                })
                .UseUrls("http://localhost:5000", "https://localhost:5001")
                .UseIISIntegration()
                .Build();

                host.Run();
        }
    }
}
