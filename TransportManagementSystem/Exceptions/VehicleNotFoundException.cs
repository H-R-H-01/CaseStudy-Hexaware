using System;

namespace TransportManagementSystem.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException() : base("Vehicle not found") { }

        public VehicleNotFoundException(string message) : base(message) { }

        public VehicleNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
