namespace TransportManagementSystem.Entities
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int TripID { get; set; }
        public int PassengerID { get; set; }
        public string BookingDate { get; set; }

        public override string ToString()
        {
            return $"BookingId: {BookingID}, TripId: {TripID}, PassengerId: {PassengerID}, BookingDate: {BookingDate}";
        }
    }
}
