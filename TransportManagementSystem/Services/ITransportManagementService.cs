using TransportManagementSystem.Entities;

namespace TransportManagementSystem.Services
{
    public interface ITransportManagementService
    {
        bool AddVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int vehicleId);
        bool ScheduleTrip(int vehicleId, int routeId, string departureDate, string arrivalDate);
        bool CancelTrip(int tripId);
        bool BookTrip(int tripId, int passengerId, string bookingDate);
        bool CancelBooking(int bookingId);
        bool AllocateDriver(int driverId);
        bool DeallocateDriver(int driverId);
        List<Booking> GetBookingsByPassenger(int passengerId);
        List<Booking> GetBookingsByTrip(int tripId);
        List<Driver> GetAvailableDrivers();
    }
}
