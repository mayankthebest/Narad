using System;
using System.Collections.Generic;
using System.Text;

namespace Narad.Extensions.Configuration.CosmosDBBase
{
    public class CosmosDBClientSettings
    {
        public string EndpointUrl { get; set; }

        public string PrimaryKey { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}
