using Microsoft.Extensions.Configuration;
using System;


namespace Narad.Extensions.Configuration.CosmosDBBase
{
    public static class CosmosDBConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddCosmosDB(
            this IConfigurationBuilder configurationBuilder, CosmosDBClientSettings defaultSettings)
        {
            if (defaultSettings == null)
            {
                throw new ArgumentNullException(nameof(defaultSettings));
            }

            configurationBuilder.Add(new CosmosDBConfigurationProvider(defaultSettings));
            return configurationBuilder;
        }


        public static IConfigurationBuilder AddCosmosDB(
            this IConfigurationBuilder configurationBuilder,
            Action<CosmosDBClientSettings, IConfiguration> setterFn)
        {
            var settings = new CosmosDBClientSettings();

            setterFn.Invoke(settings, configurationBuilder.Build());

            return configurationBuilder.AddCosmosDB(settings);
        }
    }
}
