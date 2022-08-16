//libraries / nuget - packages / directories
using locustrace.Shared;

namespace locustrace.Client.Services
{
    //interface for TokenService
    public interface ITokenService
    {
        //method to get token from api
        Task<Token> GetToken();

        //method to validate fetched token through api
        Task<TokenValidation> ValidateToken(string token);
    }
}
