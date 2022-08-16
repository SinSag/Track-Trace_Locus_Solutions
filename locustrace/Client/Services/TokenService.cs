//libraries / nuget - packages / directories
using locustrace.Shared;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

/// <summary>
/// THIS CLASS IS NOT REALLY IN USE, ONLY FOR TEST PURPOSES IN EARLY-DEV
/// </summary>

namespace locustrace.Client.Services
{
    //api-token handling, inherits from ITokenService
    public class TokenService : ITokenService
    {
        //creates instances of HttpClient and IConfigService
        private readonly HttpClient _httpClient;
        private readonly IConfigService _configService;

        //initiates the instances of HttpClient and IConfigService
        public TokenService(HttpClient httpClient, IConfigService configService)
        {
            _httpClient = httpClient;
            _configService = configService;
        }

        //method for fetching token from api
        public async Task<Token> GetToken()
        {
            //fetches values from config file and creates an object of type Config
            var config = await _configService.GetConfig();

            //assigns the request method "POST" and Uri to the request object
            var authRequest = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/Authentication");

            //defines values for the request content + CONTENT-TYPE header
            authRequest.Content = new StringContent(JsonSerializer.Serialize(config), Encoding.UTF8, "application/json-patch+json");

            //sending the request object to the uri specified in the httpclient object, and getting the response
            var response = await _httpClient.SendAsync(authRequest);

            //checking if response is valid
            response.EnsureSuccessStatusCode();

            //reading content response from API
            var responseStream = await response.Content.ReadAsStreamAsync();

            //deserializes the response into an object of type Token
            var tokenObject = await JsonSerializer.DeserializeAsync<Token>(responseStream);

            //returns the object of type Token
            return tokenObject;
        }

        //method to valdiate fetched token
        public async Task<TokenValidation> ValidateToken(string token)
        {
            //assigns the request method "GET" and Uri to the request object
            var valRequest = new HttpRequestMessage(HttpMethod.Get, "/api/v1.0/Authentication/Validate");

            //specifies the scheme and provides the token for validation
            valRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //sending the request object to the uri specified in the httpclient object, and getting the response
            var response = await _httpClient.SendAsync(valRequest);

            //checking if response is valid
            response.EnsureSuccessStatusCode();

            //reading content response from API
            var responseStream = await response.Content.ReadAsStreamAsync();

            //deserializes the response into an object of type TokenValidation
            var validatedToken = await JsonSerializer.DeserializeAsync<TokenValidation>(responseStream);

            //returns the object of type TokenValidation
            return validatedToken;
        }
    }
}
