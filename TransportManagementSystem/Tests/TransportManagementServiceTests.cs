using NUnit.Framework;
using System;
using System.Collections.Generic;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Exceptions;
using TransportManagementSystem.Services;

namespace Tests
{
    [TestFixture]
    public class TransportManagementServiceTests
    {
        private ITransportManagementService _service;

        [SetUp]
        public void Setup()
        {
            _service = new TransportManagementServiceImpl();
        }

        [Test]
        public void AddVehicle_ShouldReturnTrue_WhenValidVehicleIsAdded()
        {
            var vehicle = new Vehicle
            {
                Model = "Toyota Corolla",
                Capacity = 5,
                Type = "Sedan",
                Status = "Available"
            };

            var result = _service.AddVehicle(vehicle);

            Assert.That(result, Is.True, "Vehicle should be added successfully");
        }

        [Test]
        public void UpdateVehicle_ShouldReturnTrue_WhenVehicleExists()
        {
            var vehicle = new Vehicle
            {
                VehicleId = 1,
                Model = "Honda Civic",
                Capacity = 4,
                Type = "Sedan",
                Status = "In Service"
            };

            var result = _service.UpdateVehicle(vehicle);

            Assert.That(result, Is.True, "Vehicle should be updated successfully");
        }

        [Test]
        public void ScheduleTrip_ShouldReturnTrue_WhenValidDataIsProvided()
        {
            var result = _service.ScheduleTrip(1, 1, "2024-11-25", "2024-11-30");

            Assert.That(result, Is.True, "Trip should be scheduled successfully");
        }

        [Test]
        public void BookTrip_ShouldReturnTrue_WhenValidBookingIsMade()
        {
            var result = _service.BookTrip(1, 1, "2024-11-23");

            Assert.That(result, Is.True, "Booking should be successful");
        }

        [Test]
        public void AllocateDriver_ShouldReturnTrue_WhenValidDriverIsAllocated()
        {
            var result = _service.AllocateDriver(1);

            Assert.That(result, Is.True, "Driver should be allocated successfully");
        }

        [Test]
        public void DeallocateDriver_ShouldReturnTrue_WhenDriverIsDeallocated()
        {
            var result = _service.DeallocateDriver(1);

            Assert.That(result, Is.True, "Driver should be deallocated successfully");
        }


    }
}
