namespace locustrace.Client.Services
{
    //interface for SessionHandlerService
    public interface ISessionHandlerService
    {
        //method to initialize session with user credentials
        Task StartSession(string username, string token);

        //method to get session username
        Task<string> GetUsername();

        //method to get session token
        Task<string> GetToken();

        //method to end session and remove values saved in session
        void EndSession();

        //method to get user state
        Task<bool> GetUserState();

        //method to set logo
        Task SetLogo(string image);

        //method to get logo
        Task<string> GetLogo();
    }
}
