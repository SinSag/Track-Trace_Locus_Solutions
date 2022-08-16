//libraries / nuget - packages / directories
using locustrace.Shared;

namespace locustrace.Client.Services
{
    //interface for VehicleService
    public interface IVehicleService
    {
        //creates a list of objects of type Vehicle
        List<Vehicle> vehicles { get; set; }

        //private method for fetching vehicle information
        Task<List<Vehicle>> GetVehicleInformation(int tripId, string token);
    }
}
