using System;
using Narad.Extensions.Configuration.CosmosDBBase;
using Microsoft.Extensions.Configuration;


namespace Narad.Extensions.Configuration.CosmosDBCore
{
    public static class CosmosDBConfigurationBuilderExtensionsCore
    {
        public static IConfigurationBuilder AddCosmosDB(this IConfigurationBuilder configurationBuilder, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentNullException(nameof(configurationBuilder));
            }

            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            var settings = new CosmosDBClientSettings()
            {
                DatabaseName = environment.ApplicationName,
                CollectionName = environment.EnvironmentName
            };

            return configurationBuilder.AddCosmosDB(settings);
        }
    }
}
