using System;
using System.Collections.Generic;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.Services;

namespace TransportManagementSystem.MainApp
{
    public class TransportManagementApp
    {
        private readonly ITransportManagementService _service;

        public TransportManagementApp()
        {
            _service = new TransportManagementServiceImpl();
        }

        public void menu()
        {
            while (true)
            {
                Console.WriteLine("\n------------------- Transport Management System ------------------- ");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. Update Vehicle");
                Console.WriteLine("3. Delete Vehicle");
                Console.WriteLine("4. Schedule Trip");
                Console.WriteLine("5. Cancel Trip");
                Console.WriteLine("6. Book Trip");
                Console.WriteLine("7. Cancel Booking");
                Console.WriteLine("8. Allocate Driver");
                Console.WriteLine("9. Deallocate Driver");
                Console.WriteLine("10. Get Bookings by Passenger");
                Console.WriteLine("11. Get Bookings by Trip");
                Console.WriteLine("12. Get Available Drivers");
                Console.WriteLine("13. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddVehicle();
                        break;
                    case 2:
                        UpdateVehicle();
                        break;
                    case 3:
                        DeleteVehicle();
                        break;
                    case 4:
                        ScheduleTrip();
                        break;
                    case 5:
                        CancelTrip();
                        break;
                    case 6:
                        BookTrip();
                        break;
                    case 7:
                        CancelBooking();
                        break;
                    case 8:
                        AllocateDriver();
                        break;
                    case 9:
                        DeallocateDriver();
                        break;
                    case 10:
                        GetBookingsByPassenger();
                        break;
                    case 11:
                        GetBookingsByTrip();
                        break;
                    case 12:
                        GetAvailableDrivers();
                        break;
                    case 13:
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddVehicle()
        {
            Console.WriteLine("\nEnter Vehicle Details:");
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Write("Status (available/ on trip /maintanence): ");
            string status = Console.ReadLine();

            var vehicle = new Vehicle
            {
                Model = model,
                Capacity = capacity,
                Type = type,
                Status = status
            };

            if (_service.AddVehicle(vehicle))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicle added successfully.");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to add vehicle.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void UpdateVehicle()
        {
            Console.WriteLine("\nEnter Vehicle Details for Update:");
            Console.Write("Vehicle ID: ");
            int vehicleId = int.Parse(Console.ReadLine());
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Console.Write("Status (available/ on trip /maintanence): ");
            string status = Console.ReadLine();

            var vehicle = new Vehicle
            {
                VehicleId = vehicleId,
                Model = model,
                Capacity = capacity,
                Type = type,
                Status = status
            };

            if (_service.UpdateVehicle(vehicle))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicle updated successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to update vehicle.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void DeleteVehicle()
        {
            Console.Write("\nEnter Vehicle ID to delete: ");
            int vehicleId = int.Parse(Console.ReadLine());

            if (_service.DeleteVehicle(vehicleId))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Vehicle deleted successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Failed to delete vehicle.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void ScheduleTrip()
        {
            Console.Write("\nEnter Vehicle ID: ");
            int vehicleId = int.Parse(Console.ReadLine());
            Console.Write("Enter Route ID: ");
            int routeId = int.Parse(Console.ReadLine());
            Console.Write("Enter Departure Date (yyyy-mm-dd): ");
            string departureDate = Console.ReadLine();
            Console.Write("Enter Arrival Date (yyyy-mm-dd): ");
            string arrivalDate = Console.ReadLine();

            if (_service.ScheduleTrip(vehicleId, routeId, departureDate, arrivalDate))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Trip scheduled successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to schedule trip.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void CancelTrip()
        {
            Console.Write("\nEnter Trip ID to cancel: ");
            int tripId = int.Parse(Console.ReadLine());

            if (_service.CancelTrip(tripId))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Trip canceled successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to cancel trip.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void BookTrip()
        {
            Console.Write("\nEnter Trip ID: ");
            int tripId = int.Parse(Console.ReadLine());
            Console.Write("Enter Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());
            //Console.Write("Enter Booking Date (yyyy-mm-dd): ");
            //string bookingDate = Console.ReadLine();
            string bookingDate = DateTime.Now.ToString("yyyy-MM-dd");

            if (_service.BookTrip(tripId, passengerId, bookingDate))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Trip booked successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to book trip");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void CancelBooking()
        {
            Console.Write("\nEnter Booking ID to cancel: ");
            int bookingId = int.Parse(Console.ReadLine());

            if (_service.CancelBooking(bookingId))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Booking canceled successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to cancel booking.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void AllocateDriver()
        {
            Console.Write("Enter Driver ID to allocate: ");
            int driverId = int.Parse(Console.ReadLine());

            if (_service.AllocateDriver(driverId))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Driver allocated successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to allocate driver. The driver might already be allocated.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void DeallocateDriver()
        {
            Console.Write("Enter Driver ID to deallocate: ");
            int driverId = int.Parse(Console.ReadLine());

            if (_service.DeallocateDriver(driverId))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Driver deallocated successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Failed to deallocate driver. The driver might already be available.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }


        private void GetBookingsByPassenger()
        {
            Console.Write("\nEnter Passenger ID: ");
            int passengerId = int.Parse(Console.ReadLine());

            var bookings = _service.GetBookingsByPassenger(passengerId);

            if (bookings.Count > 0)
            {
                Console.WriteLine("\nBookings by Passenger:");
                bookings.ForEach(Console.WriteLine);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No bookings found for the passenger.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void GetBookingsByTrip()
        {
            Console.Write("\nEnter Trip ID: ");
            int tripId = int.Parse(Console.ReadLine());

            var bookings = _service.GetBookingsByTrip(tripId);

            if (bookings.Count > 0)
            {
                Console.WriteLine("\nBookings for the Trip:");
                bookings.ForEach(Console.WriteLine);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No bookings found for the trip.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private void GetAvailableDrivers()
        {
            var drivers = _service.GetAvailableDrivers();

            if (drivers.Count > 0)
            {
                Console.WriteLine("\nAvailable Drivers:");
                drivers.ForEach(Console.WriteLine);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No available drivers found.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
