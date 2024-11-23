using TransportManagementSystem.Utilities;
using System.Data.SqlClient;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Repository;


namespace TransportManagementSystem.Repository
{
    public class VehicleRepository : IVehicleRepository
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
                    string query = "UPDATE Vehicles SET Model = @Model, Capacity = @Capacity, V_Type = @VType, V_Status = @VStatus WHERE VehicleID = @VehicleId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Capacity", vehicle.Capacity);
                    cmd.Parameters.AddWithValue("@VType", vehicle.Type);
                    cmd.Parameters.AddWithValue("@VStatus", vehicle.Status);
                    cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
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
                    string query = "DELETE FROM Vehicles WHERE VehicleID = @VehicleId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error deleting vehicle: {e.Message}");
                return false;
            }
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Vehicles WHERE VehicleID = @VehicleId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Vehicle
                            {
                                VehicleId = reader.GetInt32(0),
                                Model = reader.GetString(1),
                                Capacity = reader.GetInt32(2),
                                Type = reader.GetString(3),
                                Status = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching vehicle: {e.Message}");
            }
            return null;
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            try
            {
                using (var conn = DBconnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM Vehicles";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vehicles.Add(new Vehicle
                            {
                                VehicleId = reader.GetInt32(0),
                                Model = reader.GetString(1),
                                Capacity = reader.GetInt32(2),
                                Type = reader.GetString(3),
                                Status = reader.GetString(4)
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching vehicles: {e.Message}");
            }
            return vehicles;
        }
    }
}
