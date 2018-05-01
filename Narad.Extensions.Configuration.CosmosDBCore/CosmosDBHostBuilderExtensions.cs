using Microsoft.AspNetCore.Hosting;

namespace Narad.Extensions.Configuration.CosmosDBCore
{
    public static class CosmosDBHostBuilderExtensions
    {
        public static IWebHostBuilder AddCosmosDB(this IWebHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddCosmosDB(context.HostingEnvironment);
            });
            return hostBuilder;
        }
    }
}
