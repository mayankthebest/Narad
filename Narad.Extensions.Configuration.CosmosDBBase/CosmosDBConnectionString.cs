using System;
using System.Data.Common;


namespace Narad.Extensions.Configuration.CosmosDBBase
{
    /// <summary>
    /// See https://stackoverflow.com/questions/41683369/documentdb-net-client-using-connection-string
    /// </summary>
    public class CosmosDBConnectionString
    {
        public Uri ServiceEndpoint { get; set; }

        public string AuthKey { get; set; }


        public CosmosDBConnectionString(string connectionString)
        {
            // Use this generic builder to parse the connection string
            DbConnectionStringBuilder builder = new DbConnectionStringBuilder
            {
                ConnectionString = connectionString
            };

            if (builder.TryGetValue("AccountKey", out var key))
            {
                AuthKey = key.ToString();
            }

            if (builder.TryGetValue("AccountEndpoint", out var uri))
            {
                ServiceEndpoint = new Uri(uri.ToString());
            }
        }
    }
}
