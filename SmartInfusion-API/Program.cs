using DataLayer.DbContext;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SmartInfusion.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args)
                .Seed()
                .Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000")
                .Build();
    }
}
