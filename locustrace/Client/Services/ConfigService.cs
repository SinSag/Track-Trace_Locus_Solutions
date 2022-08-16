//libraries / nuget - packages / directories
using locustrace.Shared;
using System.Net.Http.Json;

namespace locustrace.Client.Services
{
    //handles the config file, inherits from IConfigService
    public class ConfigService : IConfigService
    {
        //creates a instances of HttpClient
        private readonly HttpClient _httpClient;

        //initializes the HttpClient
        public ConfigService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //method to fetch json config file
        public async Task<Config> GetConfig()
        {
            var config = await _httpClient.GetFromJsonAsync<Config>("appsettings.json");
            return config;
        }
    }
}
