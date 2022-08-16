//libraries / nuget - packages / directories
using locustrace.Shared;
using System.Net.Http.Headers;
using System.Text.Json;

namespace locustrace.Client.Services
{
    //handles order information, inherits from IOrderService
    public class OrderService : IOrderService
    {
        //creates an instance of HttpClient
        private readonly HttpClient _httpClient;

        //creates a list of objects of type OpenOrder
        public List<OpenOrder> openOrders { get; set; } = new List<OpenOrder>();

        //creates a list of objects of type PrivateOrder
        public List<PrivateOrder> privateOrders { get; set; } = new List<PrivateOrder>();

        //initializes the instance of HttpClient
        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //method to get open tracking information
        public async Task<List<OpenOrder>> GetOpenTrackingInformation(string orderId)
        {
            //assigns the request method "GET" and Uri to the request object
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1.0/Students/Get/GetOpenTrackingInformation/{orderId}");

            //sending the request object to the uri specified in the httpclient object, and getting the response
            var response = await _httpClient.SendAsync(orderRequest);

            //catches exception if response is false
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Reason: {response.ReasonPhrase}, Message:");
            }

            //reading content response from API
            var responseStream = await response.Content.ReadAsStreamAsync();

            //deserializes the response into a list of objects of type OpenOrder
            openOrders = await JsonSerializer.DeserializeAsync<List<OpenOrder>>(responseStream);

            //if request returns with 0 results throw exception
            if (openOrders.Count < 1)
            {
                throw new ApplicationException($"Reason: {response.ReasonPhrase}, Message:");
            }

            //returns the open order object
            return openOrders;
        }

        //method to get private tracking information
        public async Task<List<PrivateOrder>> GetTrackingInformation(string orderId, string token)
        {
            //assigns the request method "GET" and Uri to the request object
            var orderRequest = new HttpRequestMessage(HttpMethod.Get, $"/api/v1.0/Students/Get/GetTrackingInformation/{orderId}");

            //defines the header of the HTTP request object with scheme and provided token
            orderRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //sending the request object to the uri specified in the httpclient object, and getting the response
            var response = await _httpClient.SendAsync(orderRequest);

            //catches exception if response is false
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Reason: {response.ReasonPhrase}, Message:");
            }

            //reading content response from API
            var responseStream = await response.Content.ReadAsStreamAsync();

            //deserializes the response into a list of objects of type PrivateOrder
            privateOrders = await JsonSerializer.DeserializeAsync<List<PrivateOrder>>(responseStream);

            //if request returns with 0 results throw exception
            if (privateOrders.Count < 1)
            {
                throw new ApplicationException($"Reason: {response.ReasonPhrase}, Message:");
            }

            //returns the private order object
            return privateOrders;
        }
    }
}
