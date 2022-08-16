//libraries / nuget - packages / directories
using Blazored.SessionStorage;

namespace locustrace.Client.Services
{
    //service to handle sessions, inherits from ISessionHandlerService
    public class SessionHandlerService : ISessionHandlerService
    {
        //creates an instance of the ISessionStorageService, provided by the nuget-package
        private readonly ISessionStorageService _session;

        //initiates the instance of ISessionStorage
        public SessionHandlerService(ISessionStorageService sessionSorageService)
        {
            _session = sessionSorageService;
        }

        //method to start session and set session values
        public async Task StartSession(string username, string token)
        {
            await _session.SetItemAsStringAsync("username", username);
            await _session.SetItemAsStringAsync("token", token);
            await _session.SetItemAsync<bool>("status", true);
        }

        //method to end session and clear session values
        public async void EndSession()
        {
            await _session.ClearAsync();
        }

        //method to get user state
        public async Task<bool> GetUserState()
        {
            bool isLoggedIn = await _session.GetItemAsync<bool>("status");
            return isLoggedIn;
        }

        //method to get session username
        public async Task<string> GetUsername()
        {
            return await _session.GetItemAsStringAsync("username");
        }

        //method to get session token
        public async Task<string> GetToken()
        {
            return await _session.GetItemAsStringAsync("token");
        }

        //method to set logo
        public async Task SetLogo(string image)
        {
            await _session.SetItemAsStringAsync("logo", image);
        }

        //method to get logo
        public async Task<string> GetLogo()
        {
            return await _session.GetItemAsStringAsync("logo");
        }
    }
}
