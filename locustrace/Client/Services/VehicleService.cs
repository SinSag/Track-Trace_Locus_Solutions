//libraries / nuget - packages / directories
using locustrace.Shared;
using System.Net.Http.Headers;
using System.Text.Json;

namespace locustrace.Client.Services
{
    //class to handle vehicle information, inherits from IVehicleService
    public class VehicleService : IVehicleService
    {
        //creates an instance of HttpClient
        private readonly HttpClient _httpClient;

        //creates an instance of Vehicle
        public List<Vehicle> vehicles { get; set; }

        //initiates the instance of HttpClient
        public VehicleService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //private method to get vehicle information
        public async Task<List<Vehicle>> GetVehicleInformation(int tripId, string token)
        {
            //assigns the request method "GET" and Uri to the request object
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1.0/Students/Get/GetVehicleInformation/{tripId}");

            //defines the header of the HTTP request object with scheme and provided token
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //sending the request object to the uri specified in the httpclient object, and getting the response
            var response = await _httpClient.SendAsync(orderRequest);

            //checking if response is valid
            response.EnsureSuccessStatusCode();

            //reading content response from API
            var responseStream = await response.Content.ReadAsStreamAsync();

            //deserializes the response into a list of objects of type Vehicle
            vehicles = await JsonSerializer.DeserializeAsync<List<Vehicle>>(responseStream);

            //returns the object of type Vehicle
            return vehicles;
        }
    }
}
