-- ================================
-- Cleaned Flight Booking System LLD
-- ================================

-- Drop tables if needed
DROP TABLE IF EXISTS Booking;
DROP TABLE IF EXISTS Flight;
DROP TABLE IF EXISTS Passenger;
DROP TABLE IF EXISTS Airplane;

-- ================================
-- Main Entity Tables (with status inlined)
-- ================================

CREATE TABLE Passenger (
    PassengerID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PassportNumber VARCHAR(20) UNIQUE NOT NULL,
    Nationality VARCHAR(50),
    PhoneNumber VARCHAR(20),
    Status VARCHAR(10) NOT NULL CHECK (Status IN ('Active', 'Inactive'))
);

CREATE TABLE Airplane (
    AirplaneID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Model VARCHAR(100) NOT NULL,
    Manufacturer VARCHAR(100),
    Capacity INT NOT NULL,
    InService BIT NOT NULL DEFAULT 1  -- 1 = Yes, 0 = No
);

CREATE TABLE Flight (
    FlightID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    DepartureAirport VARCHAR(100) NOT NULL,
    ArrivalAirport VARCHAR(100) NOT NULL,
    DepartureDateTime DATETIME NOT NULL,
    ArrivalDateTime DATETIME NOT NULL,
    Status VARCHAR(10) NOT NULL CHECK (Status IN ('On Time', 'Delayed', 'Cancelled')),
    AirplaneID UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (AirplaneID) REFERENCES Airplane(AirplaneID)
);

CREATE TABLE Booking (
    BookingID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PassengerID UNIQUEIDENTIFIER NOT NULL,
    FlightID UNIQUEIDENTIFIER NOT NULL,
    SeatNumber VARCHAR(10) NOT NULL,
    BookingDate DATETIME NOT NULL DEFAULT GETDATE(),
    Status VARCHAR(10) NOT NULL CHECK (Status IN ('Confirmed', 'Cancelled', 'Pending')),
    FOREIGN KEY (PassengerID) REFERENCES Passenger(PassengerID),
    FOREIGN KEY (FlightID) REFERENCES Flight(FlightID)
);