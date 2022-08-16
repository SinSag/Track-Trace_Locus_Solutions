//libraries / nuget - packages / directories
using locustrace.Shared;

namespace locustrace.Client.Services
{
    //interface for ConfigService
    public interface IConfigService
    {
        //method to fetch json config file
        Task<Config> GetConfig();
    }
}
