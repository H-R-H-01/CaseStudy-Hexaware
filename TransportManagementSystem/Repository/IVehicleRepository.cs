using TransportManagementSystem.Entities;
using System.Collections.Generic;

namespace TransportManagementSystem.Repository
{
    public interface IVehicleRepository
    {
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int vehicleId);
        Vehicle GetVehicleById(int vehicleId);
        List<Vehicle> GetAllVehicles();
    }
}
