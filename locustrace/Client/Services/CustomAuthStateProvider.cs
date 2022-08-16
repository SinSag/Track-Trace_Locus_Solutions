//libraries / nuget - packages / directories
using System.Security.Claims;

namespace locustrace.Client.Services
{
    //class to authorize users, inherits from AuthenticationStateProvider
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        //creates an instance of the session handler service
        private readonly ISessionHandlerService SessionHandlerService;

        //initiates the session handler service
        public CustomAuthStateProvider(ISessionHandlerService sessionHandlerService)
        {
            SessionHandlerService = sessionHandlerService;
        }

        //method to create a authorized user
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //gets user token from session
            var token = await SessionHandlerService.GetToken();

            //creates a claim identity
            var id = new ClaimsIdentity(token);

            //creates a new claims prinicpal
            var user = new ClaimsPrincipal(id);

            //creates a new authentication state with the claim prinicpal
            var state = new AuthenticationState(user);

            //notifies the authenticaiton state change
            NotifyAuthenticationStateChanged(Task.FromResult(state));

            //returns state
            return state;
        }
    }
}
