using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Narad.Extensions.Configuration.CosmosDBSampleClient.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Narad.Extensions.Configuration.CosmosDBSampleClient.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IOptionsSnapshot<CosmosDBData> ICosmosDBData { get; set; }

        public ValuesController(IConfigurationRoot config, IOptionsSnapshot<CosmosDBData> azureTableData)
        {
            if (azureTableData != null)
                ICosmosDBData = azureTableData;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            if (ICosmosDBData != null && ICosmosDBData.Value != null)
            {
                var data = ICosmosDBData.Value;
                return new string[] { data.Bar, data.Foo };
            }
            else
                return new string[] { "value1", "value2" };
        }
    }
}
