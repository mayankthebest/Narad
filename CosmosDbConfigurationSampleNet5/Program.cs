using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Narad.Extensions.Configuration.CosmosDBBase;


namespace CosmosDbConfigurationSampleNet5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddUserSecrets(typeof(Startup).Assembly)
                           .AddCosmosDB((dbSettings, config) =>
                           {
                               dbSettings.ConnectionString = config.GetSection("CosmosDbConnection").Value;
                               dbSettings.DatabaseName = config.GetSection("CosmosDbDatabase").Value;
                               dbSettings.CollectionName = config.GetSection("SettingsCollection").Value;
                           });
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
