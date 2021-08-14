using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace CosmosDbConfigurationSampleNet5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        public IOptionsSnapshot<CosmosDBData> Config { get; private set; }


        public IndexModel(ILogger<IndexModel> logger, IOptionsSnapshot<CosmosDBData> config)
        {
            _logger = logger;
            Config = config;
        }


        public void OnGet()
        {
        }
    }
}
