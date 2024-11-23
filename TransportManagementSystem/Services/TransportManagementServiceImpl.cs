using System.Data.Common;
using System.Data.SqlClient;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.Services;
using TransportManagementSystem.Utilities;

namespace TransportManagementSystem.Services
{
    public class TransportManagementServiceImpl : ITransportManagementService
    {
        public bool AddVehicle(Vehicle vehicle)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Vehicles (Model, Capacity, V_Type, V_Status) VALUES (@Model, @Capacity, @VType, @VStatus)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                    cmd.Parameters.AddWithValue("@VType", vehicle.Type);
                    cmd.Parameters.AddWithValue("@VStatus", vehicle.Status);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error adding vehicle: {e.Message}");
                return false;
            }
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE Vehicles SET Model = @Model, Capacity = @Capacity, V_Type = @VType, V_Status = @VStatus WHERE VehicleID = @VehicleID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                    cmd.Parameters.AddWithValue("@VType", vehicle.Type);
                    cmd.Parameters.AddWithValue("@VStatus", vehicle.Status);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicle.VehicleId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error updating vehicle: {e.Message}");
                return false;
            }
        }
        public bool DeleteVehicle(int vehicleId)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM Vehicles WHERE VehicleID = @VehicleId";
                    SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                    int count = (int)checkCmd.ExecuteScalar();
                    if (count == 0)
                    {
                        throw new VehicleNotFoundException($"Vehicle with ID {vehicleId} does not exist.");
                    }

                    string deleteQuery = "DELETE FROM Vehicles WHERE VehicleID = @VehicleId";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn);
                    deleteCmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                    return deleteCmd.ExecuteNonQuery() > 0;
                }
            }
            catch (VehicleNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("VehicleNotFoundException : " + e.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error deleting vehicle: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }


        public bool ScheduleTrip(int vehicleId, int routeId, string departureDate, string arrivalDate)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Trips (VehicleID, RouteID, DepartureDate, ArrivalDate) VALUES (@VehicleID, @RouteID, @DepartureDate, @ArrivalDate)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleID", vehicleId);
                    cmd.Parameters.AddWithValue("@RouteID", routeId);
                    cmd.Parameters.AddWithValue("@DepartureDate", departureDate);
                    cmd.Parameters.AddWithValue("@ArrivalDate", arrivalDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error scheduling trip: {e.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        public bool CancelTrip(int tripId)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Trips WHERE TripID = @TripID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TripID", tripId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error canceling trip: {e.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        public bool BookTrip(int tripId, int passengerId, string bookingDate)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO Bookings (TripID, PassengerID, BookingDate) VALUES (@TripID, @PassengerID, @BookingDate)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TripID", tripId);
                    cmd.Parameters.AddWithValue("@PassengerID", passengerId);
                    cmd.Parameters.AddWithValue("@BookingDate", bookingDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error booking trip: {e.Message}");
                Console.ForegroundColor = ConsoleColor.White;

                return false;
            }
        }

        public bool CancelBooking(int bookingId)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM Bookings WHERE BookingID = @BookingID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error canceling booking: {e.Message}");
                return false;
            }
        }

        public bool AllocateDriver(int driverId)
{
    try
    {
        using (var conn = DBconnection.GetConnection())
        {
            conn.Open();
            string query = "UPDATE Drivers SET D_Status = 1 WHERE DriverID = @DriverID AND D_Status = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", driverId);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error allocating driver: {e.Message}");
        return false;
    }
}

public bool DeallocateDriver(int driverId)
{
    try
    {
        using (var conn = DBconnection.GetConnection())
        {
            conn.Open();
            string query = "UPDATE Drivers SET D_Status = 0 WHERE DriverID = @DriverID AND D_Status = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@DriverID", driverId);

            return cmd.ExecuteNonQuery() > 0;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Error deallocating driver: {e.Message}");
        return false;
    }
}


        public List<Booking> GetBookingsByPassenger(int passengerId)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT BookingID, TripID, PassengerID, BookingDate FROM Bookings WHERE PassengerID = @PassengerId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PassengerId", passengerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        var bookings = new List<Booking>();

                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                BookingID = reader.GetInt32(reader.GetOrdinal("BookingID")),
                                TripID = reader.GetInt32(reader.GetOrdinal("TripID")),
                                PassengerID = reader.GetInt32(reader.GetOrdinal("PassengerID")),
                                BookingDate = reader["BookingDate"] == DBNull.Value ? "N/A" : reader["BookingDate"].ToString()
                            });
                        }

                        if (bookings.Count == 0)
                        {
                            throw new BookingNotFoundException($"No bookings found for Passenger ID {passengerId}.");
                        }

                        return bookings;
                    }
                }
            }
            catch (BookingNotFoundException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("BookingNotFoundException : " + e.Message);
                Console.ForegroundColor = ConsoleColor.White;
                return new List<Booking>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error retrieving bookings: {e.Message}");
                return new List<Booking>();
            }
        }



        public List<Booking> GetBookingsByTrip(int tripId)
        {
            var bookings = new List<Booking>();
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Bookings WHERE TripID = @TripID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TripID", tripId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bookings.Add(new Booking
                            {
                                BookingID = (int)reader["BookingID"],
                                TripID = (int)reader["TripID"],
                                PassengerID = (int)reader["PassengerID"],
                                BookingDate = reader["BookingDate"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error retrieving bookings: {e.Message}");
            }
            return bookings;
        }

        public List<Driver> GetAvailableDrivers()
        {
            var drivers = new List<Driver>();
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Drivers WHERE D_Status = 0 ";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            drivers.Add(new Driver
                            {
                                DriverID = (int)reader["DriverID"],
                                Name = reader["Name"].ToString(),
                                LicenseNumber = reader["LicenseNumber"].ToString(),
                                Status = (bool)reader["D_Status"]
                            });
                        }
                    }
                }
            }
           
            catch (Exception e)
            {
                Console.WriteLine($"Error retrieving drivers: {e.Message}");
            }
            return drivers;
        }
    }
}
