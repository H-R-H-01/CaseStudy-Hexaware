--Case Study - Transport Management System

--creating a DB
create database TransportManagementSystem
  
--use DB
use TransportManagementSystem

--creating a Vehicles Table
create table Vehicles(
VehicleID INT IDENTITY(1,1) PRIMARY KEY,
Model VARCHAR(255),
Capacity DECIMAL(10,2),
Type VARCHAR(50),
Status VARCHAR(50)
)

--creating a Routes Table
create table Routes(
RouteID INT IDENTITY(1,1) PRIMARY KEY,
StartDestination VARCHAR(255),
EndDestination VARCHAR(255),
Distance DECIMAL(10, 2)
)

--creating a Trips Table
create table Trips(
TripID INT IDENTITY(1,1) PRIMARY KEY,
VehicleID INT FOREIGN KEY REFERENCES Vehicles(VehicleID),
RouteID INT FOREIGN KEY REFERENCES Routess(RouteID),
DepartureDate DATETIME,
ArrivalDate DATETIME,
Status VARCHAR(50),
TripType VARCHAR(50) DEFAULT 'Freight',
MaxPassengers INT
)

--creating passenger table
create table Passengers(
PassengerID INT IDENTITY(1,1) PRIMARY KEY,
FirstName VARCHAR(255),
Gender VARCHAR(255),
Age INT,
Email VARCHAR(255) UNIQUE,
PhoneNumber VARCHAR(50)
)
  
--creating bookings table
create table Bookings(
BookingId int identity PRIMARY KEY,
TripID int FOREIGN KEY REFERENCES Trips (TripID),
PassengerID INT FOREIGN KEY REFERENCES Passengers (PassengerID),
BookingDate DATETIME,
[status] VARCHAR (50)
)

-- Inserting sample data into the Vehicles table
INSERT INTO Vehicles (Model, Capacity, Type, Status)
VALUES
('Ford Transit', 1.50, 'Van', 'Available'),
('Mercedes Actros', 18.00, 'Truck', 'On Trip'),
('Volvo 9700', 50.00, 'Bus', 'Maintenance')

-- Inserting sample data into the Routes table
INSERT INTO Routes (StartDestination, EndDestination, Distance)
VALUES
('New York', 'Washington D.C.', 225.50),
('Los Angeles', 'San Francisco', 382.00),
('Chicago', 'Detroit', 280.00)

-- Inserting sample data into the Trips table
INSERT INTO Trips (VehicleID, RouteID, DepartureDate, ArrivalDate, Status, TripType, MaxPassengers)
VALUES
(1, 1, '2024-11-15 08:00:00', '2024-11-15 12:00:00', 'Scheduled', 'Passenger', 12),
(2, 2, '2024-11-16 09:00:00', '2024-11-16 17:30:00', 'Scheduled', 'Freight', NULL),
(3, 3, '2024-11-17 10:00:00', '2024-11-17 15:00:00', 'Scheduled', 'Passenger', 45)

-- Inserting sample data into the Passengers table
INSERT INTO Passengers (FirstName, Gender, Age, Email, PhoneNumber)
VALUES
('John Doe', 'Male', 34, 'johndoe@example.com', '123-456-7890'),
('Jane Smith', 'Female', 29, 'janesmith@example.com', '234-567-8901'),
('Alex Brown', 'Non-binary', 22, 'alexbrown@example.com', '345-678-9012')

-- Inserting sample data into the Bookings table
INSERT INTO Bookings (TripID, PassengerID, BookingDate, Status)
VALUES
(1, 1, '2024-11-14 15:00:00', 'Confirmed'),
(1, 2, '2024-11-14 15:05:00', 'Confirmed'),
(3, 3, '2024-11-16 18:00:00', 'Cancelled')
