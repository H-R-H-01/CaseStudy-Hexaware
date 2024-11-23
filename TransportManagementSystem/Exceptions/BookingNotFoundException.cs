using System;

namespace TransportManagementSystem.Exceptions;

public class BookingNotFoundException : Exception
{
    public BookingNotFoundException() : base("Booking not found.") { }

    public BookingNotFoundException(string message) : base(message) { }

    public BookingNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
