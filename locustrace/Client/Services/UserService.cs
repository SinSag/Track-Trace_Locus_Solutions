//libraries / nuget - packages / directories
using locustrace.Shared;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace locustrace.Client.Services
{
    //handles user login through api, inherits from IUserService
    public class UserService : IUserService
    {
        //creates instances of HttpClient and IConfigService
        private readonly HttpClient _httpClient;
        private readonly IConfigService _configService;

        //creates an instance of type TokenValidation
        public TokenValidation valResult { get; set; } = new TokenValidation();

        //initializes the instances of HttpClient and IConfigService
        public UserService(HttpClient httpClient, IConfigService configService)
        {
            _httpClient = httpClient;
            _configService = configService;
        }

        //method for fetching JWT Token from Transfleet API with login information
        public async Task<Token> GetUserToken(string username, string password)
        {
            //fetching data from config file
            var config = await _configService.GetConfig();
            string grantType = config.GrantType;
            int departmentId = config.DepartmentId;

            //puts the variables in an object
            var body = new { grantType, username, password, departmentId };

            //assigns the request method "POST" and Uri to the request object
            var authRequest = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/Authentication");

            //defines values for the request content + CONTENT-TYPE header
            authRequest.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json-patch+json");

            //sending the request object to the uri specified in the httpclient object, and getting the response
            var response = await _httpClient.SendAsync(authRequest);

            //if password/username is wrong, an ApplicationException is created
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Reason: {response.ReasonPhrase}, Message:");
            }

            //checking if response is valid
            response.EnsureSuccessStatusCode();

            //reading content response from API
            var responseStream = await response.Content.ReadAsStreamAsync();

            //deserializes the response into an object of type Token
            var authResult = await JsonSerializer.DeserializeAsync<Token>(responseStream);

            //returns the object of type Token
            return authResult;
        }

        public async Task<TokenValidation> ValidateUserToken(string token)
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
            valResult = await JsonSerializer.DeserializeAsync<TokenValidation>(responseStream);

            //returns the object of type TokenValidation
            return valResult;
        }

        //method to validate user input
        public async Task<string> ValidateUserInput(string username, string password)
        {
            //variable to hold error response
            string errorMessage = "";

            //checks if username or password is null
            if (username == null || password == null)
            {
                //sets error message
                errorMessage += "Fields missing.";
            }

            //returns error message
            return errorMessage;
        }

        //method to fetch customer logo (not finished)
        public async Task<BinaryReader> GetCustomerLogo(string username, string token)
        {
            //assigns the request method "GET" and Uri to the request object
            var imgRequest = new HttpRequestMessage(HttpMethod.Get, $"enter the URI for fetching image/{username}");

            //specifies the scheme and provides the token
            imgRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //sending the request object to the uri specified in the httpclient object, and getting the response
            var response = await _httpClient.SendAsync(imgRequest);

            //checking if response is valid
            response.EnsureSuccessStatusCode();

            //reading content response from API
            var responseStream = await response.Content.ReadAsStreamAsync();

            //deserializes the response into an object of type Binary Reader
            var imgObject = await JsonSerializer.DeserializeAsync<BinaryReader>(responseStream);

            //returns the object of type Binary Reader
            return imgObject;
        }
    }
}
