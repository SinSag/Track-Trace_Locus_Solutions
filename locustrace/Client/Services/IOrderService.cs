//libraries / nuget - packages / directories
using locustrace.Shared;

namespace locustrace.Client.Services
{
    //interface for OrderService
    public interface IOrderService
    {
        //list of open order objects
        List<OpenOrder> openOrders { get; set; }

        //list of private order objects
        List<PrivateOrder> privateOrders { get; set; }

        //public method for fetching order
        Task<List<OpenOrder>> GetOpenTrackingInformation(string orderId);

        //private method for fetching order
        Task<List<PrivateOrder>> GetTrackingInformation(string orderId, string token);
    }
}
