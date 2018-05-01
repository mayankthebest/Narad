using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Narad.Extensions.Configuration.CosmosDBSampleClient.Model
{
    /// <summary>
    /// An object used with the DI Options mechanism for exposing the data retrieved 
    /// from the Azure Table Storage
    /// </summary>
    public class CosmosDBData
    {
        public string Bar { get; set; }
        public string Foo { get; set; }
        public Info Info { get; set; }
    }

    public class Info
    {
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
