namespace TransportManagementSystem.Entities
{
    public class Driver
    {
        public int DriverID { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public bool Status { get; set; } //--> 0-Available 1-Allocated 

        public override string ToString()
        {
            return $"DriverID: {DriverID}, Name: {Name}, LicenseNumber: {LicenseNumber}, Available: {!Status}";
        }
    }
}
