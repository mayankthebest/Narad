namespace Narad.Extensions.Configuration.CosmosDBBase
{
    public class CosmosDBClientSettings
    {
        /// <summary>
        /// If this one is defined, it overrides <see cref="EndpointUrl"/> and <see cref="PrimaryKey"/>.
        /// </summary>
        public string ConnectionString { get; set; }


        public string EndpointUrl { get; set; }

        public string PrimaryKey { get; set; }


        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
