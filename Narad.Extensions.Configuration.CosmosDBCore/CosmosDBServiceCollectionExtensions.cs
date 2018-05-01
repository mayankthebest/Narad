using Narad.Extensions.Configuration.CosmosDBBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Narad.Extensions.Configuration.CosmosDBCore
{
    public static class CosmosDBServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureCosmosDBClientOptions(this IServiceCollection services, IConfiguration config)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            services.AddOptions();

            var section = config.GetSection(CosmosDBConfigurationProvider.PREFIX);
            services.Configure<CosmosDBClientSettings>(section);

            return services;
        }

        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration config)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            services.AddOptions();

            services.TryAddSingleton(config);

            var root = config as IConfigurationRoot;
            if (root != null)
            {
                services.TryAddSingleton(root);
            }

            return services;
        }
    }
}
