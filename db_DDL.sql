DROP TABLE IF EXISTS Payment, Booking, Flight, Airplane, Passenger, Users;

CREATE TABLE Users (
    UserID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(256) NOT NULL
);

CREATE TABLE Passenger (
    PassengerID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserID UNIQUEIDENTIFIER NOT NULL,
    FullName VARCHAR(100),
    Email VARCHAR(100),
    PassportNumber VARCHAR(50),
    Nationality VARCHAR(50),
    PhoneNumber VARCHAR(20),
    DateOfBirth Date,
    Status VARCHAR(20) CHECK (Status IN ('Active', 'Inactive')),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Airplane (
    AirplaneID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Model VARCHAR(50),
    AirLine VARCHAR(100),
    Manufacturer VARCHAR(50),
    Capacity INT,
    InService BIT
);

CREATE TABLE Flight (
    FlightID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    DepartureAirport VARCHAR(100),
    ArrivalAirport VARCHAR(100),
    AirLine VARCHAR(100),
    DepartureDateTime DATETIME,
    ArrivalDateTime DATETIME,
    Status VARCHAR(20) CHECK (Status IN ('On Time', 'Delayed', 'Cancelled')),
    AirplaneID UNIQUEIDENTIFIER,
    Price DECIMAL(10, 2),
    Class VARCHAR(20) CHECK (Class IN ('Economy', 'Business')),
    FOREIGN KEY (AirplaneID) REFERENCES Airplane(AirplaneID)
);

CREATE TABLE Booking (
    BookingID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    PassengerID UNIQUEIDENTIFIER,
    FlightID UNIQUEIDENTIFIER,
    SeatNumber VARCHAR(10),
    BookingDate DATETIME,
    Status VARCHAR(20) CHECK (Status IN ('Confirmed', 'Cancelled', 'Pending')),
    FOREIGN KEY (PassengerID) REFERENCES Passenger(PassengerID),
    FOREIGN KEY (FlightID) REFERENCES Flight(FlightID)
);

CREATE TABLE Payment (
    PaymentID UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    BookingID UNIQUEIDENTIFIER,
    Amount DECIMAL(10, 2),
    PaymentDate DATETIME,
    Method VARCHAR(50),
    Status VARCHAR(20) CHECK (Status IN ('Paid', 'Failed', 'Pending')),
    FOREIGN KEY (BookingID) REFERENCES Booking(BookingID)
);