using Microsoft.Azure.Documents.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Narad.Extensions.Configuration.CosmosDBBase
{
    public class CosmosDBConfigurationProvider : ConfigurationProvider, IConfigurationSource
    {
        private CosmosDBClientSettings _settings;
        /// <summary>
        /// The prefix (<see cref="IConfigurationSection"/> under which all Spring Cloud Config Server
        /// configuration settings (<see cref="CosmosDBClientSettings"/> are found.
        ///   (e.g. azure:cloud:config:EndpointUrl, azure:cloud:config:PrimaryKey, azure:cloud:config:DatabaseName, etc.)
        /// </summary>
        public const string PREFIX = "azure:cloud:config";

        public CosmosDBConfigurationProvider(CosmosDBClientSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            ConfigurationBuilder config = new ConfigurationBuilder();
            foreach (IConfigurationSource s in builder.Sources)
            {
                if (s == this)
                {
                    break;
                }

                config.Add(s);
            }

            IConfiguration existing = config.Build();
            InitializeConfigurationSettings(PREFIX, _settings, existing);
            return this;
        }

        private void InitializeConfigurationSettings(string configPrefix, CosmosDBClientSettings settings, IConfiguration config)
        {
            if (configPrefix == null)
            {
                throw new ArgumentNullException(nameof(configPrefix));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }

            var clientConfigsection = config.GetSection(configPrefix);
            clientConfigsection.Bind(settings);
        }

        public override void Load()
        {
            AddCosmosDBClientSettings();

            var client = new DocumentClient(new Uri(_settings.EndpointUrl), _settings.PrimaryKey);
            FeedOptions queryOptions = new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true };
            IQueryable configQuery = client.CreateDocumentQuery(UriFactory.CreateDocumentCollectionUri(_settings.DatabaseName, _settings.CollectionName), queryOptions);

            foreach (var result in configQuery)
            {
                var configurationObject = JObject.Parse(result.ToString());
                var allConfiguration = ParseProperties(configurationObject);
                foreach (var configurationItem in allConfiguration)
                {
                    Data[configurationItem.Key] = configurationItem.Value;
                }
                continue;
            }
        }

        private Dictionary<string, string> ParseProperties(JObject result)
        {
            Dictionary<string, string> allProps = new Dictionary<string, string>();
            foreach (var prop in result.Properties())
            {
                if (prop.Name.StartsWith("_"))
                {
                    continue;
                }

                string key = prop.Name;
                if (prop.Value.Type == JTokenType.Object)
                {
                    var innerKeys = ParseProperties(prop.Value as JObject);
                    foreach (var innerKey in innerKeys)
                    {
                        allProps.Add($"{key}:{innerKey.Key}", innerKey.Value);
                    }
                }
                else
                {
                    allProps.Add(key, prop.Value.ToString());
                }
            }

            return allProps;
        }

        private void AddCosmosDBClientSettings()
        {
            Data[$"{PREFIX}:{nameof(_settings.EndpointUrl)}"] = _settings.EndpointUrl;
            Data[$"{PREFIX}:{nameof(_settings.PrimaryKey)}"] = _settings.PrimaryKey;
            Data[$"{PREFIX}:{nameof(_settings.DatabaseName)}"] = _settings.DatabaseName;
            Data[$"{PREFIX}:{nameof(_settings.CollectionName)}"] = _settings.CollectionName;
        }
    }
}
