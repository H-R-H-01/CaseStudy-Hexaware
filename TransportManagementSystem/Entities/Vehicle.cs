namespace TransportManagementSystem.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }

        public Vehicle() { }

        // constructor to create object (without id)
        public Vehicle(string model, string type, int capacity, string status)
        {
            Model = model;
            Type = type;
            Capacity = capacity;
            Status = status;
        }

        // constructor to create object (with id)
        public Vehicle(int vehicleId, string model, string type, int capacity, string status)
        {
            VehicleId = vehicleId;
            Model = model;
            Type = type;
            Capacity = capacity;
            Status = status;
        }
    }
}
