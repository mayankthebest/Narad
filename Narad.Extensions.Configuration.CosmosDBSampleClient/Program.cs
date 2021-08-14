using Narad.Extensions.Configuration.CosmosDBCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace Narad.Extensions.Configuration.CosmosDBSampleClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .AddCosmosDB()
                .UseStartup<Startup>()
                .Build();
    }
}
