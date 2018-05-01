using Microsoft.Extensions.Configuration;
using System;

namespace Narad.Extensions.Configuration.CosmosDBBase
{
    public static class CosmosDBConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddCosmosDB(this IConfigurationBuilder configurationBuilder, CosmosDBClientSettings defaultSettings)
        {
            if (configurationBuilder == null)
            {
                throw new ArgumentNullException(nameof(configurationBuilder));
            }

            if (defaultSettings == null)
            {
                throw new ArgumentNullException(nameof(defaultSettings));
            }

            configurationBuilder.Add(new CosmosDBConfigurationProvider(defaultSettings));
            return configurationBuilder;
        }
    }
}
