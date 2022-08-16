//libraries / nuget - packages / directories
using locustrace.Shared;

namespace locustrace.Client.Services
{
    //interface for UserService
    public interface IUserService
    {
        //creates an object of type TokenValidation
        TokenValidation valResult { get; set; }

        //method to get token from api
        Task<Token> GetUserToken(string username, string password);

        //method to validate fetched token 
        Task<TokenValidation> ValidateUserToken(string token);

        Task<BinaryReader> GetCustomerLogo(string username, string token);

        //method to validate user input
        Task<string> ValidateUserInput(string username, string password);
    }
}
