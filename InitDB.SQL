-- Create the database
USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Re7la')
BEGIN
    CREATE DATABASE Re7la;
END
GO

USE Re7la;
GO

-- Create Users table
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role INT NOT NULL DEFAULT 1, -- 0=Admin, 1=User
    Balance DECIMAL(18,2) NOT NULL DEFAULT 0,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    DateCreated DATETIME NOT NULL DEFAULT GETUTCDATE(),
    LastLogin DATETIME,
    IsLocked BIT NOT NULL DEFAULT 0,
    DeletedAt DATETIME,
    NumberOfBookings INT NOT NULL DEFAULT 0,
    CreatedByAdminId INT,
    FailedLoginAttempts INT NOT NULL DEFAULT 0,
    LockoutEnd DATETIME,
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (CreatedByAdminId) REFERENCES dUsers(Id)
);
GO

-- Create Passengers table
CREATE TABLE Passengers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PassportNumber NVARCHAR(50) NOT NULL,
    Nationality NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    DateOfBirth DATE NOT NULL,
    DeletedAt DATETIME,
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETUTCDATE()
);
GO

-- Create BookingDetails table
CREATE TABLE BookingDetails (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FlightNumber NVARCHAR(20) NOT NULL,
    Airline NVARCHAR(50) NOT NULL,
    Origin NVARCHAR(50) NOT NULL,
    Destination NVARCHAR(50) NOT NULL,
    DepartureTime DATETIME NOT NULL,
    ArrivalTime DATETIME NOT NULL,
    OriginalPrice DECIMAL(18,2) NOT NULL,
    PassengerId INT NOT NULL,
    SeatClass NVARCHAR(20) NOT NULL,
    SeatNumber NVARCHAR(10) NOT NULL,
    PNR NVARCHAR(10) NOT NULL UNIQUE,
    DestinationImageUrl NVARCHAR(255),
    TotalPrice DECIMAL(18,2) NOT NULL,
    BookingDate DATETIME NOT NULL DEFAULT GETUTCDATE(),
    BookedByUserId INT NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Confirmed',
    DeletedAt DATETIME,
    IsNonStop BIT NOT NULL DEFAULT 1,
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    UpdatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (PassengerId) REFERENCES Passengers(Id),
    FOREIGN KEY (BookedByUserId) REFERENCES Users(Id)
);
GO

-- Create BookingStops table
CREATE TABLE BookingStops (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    BookingId INT NOT NULL,
    Airport NVARCHAR(100) NOT NULL,
    AirportCode NVARCHAR(10) NOT NULL,
    LayoverDuration BIGINT NOT NULL, -- Storing as ticks
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (BookingId) REFERENCES BookingDetails(Id)
);
GO

-- Create ActivityLogs table
CREATE TABLE ActivityLogs (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    ActivityType NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    Timestamp DATETIME NOT NULL DEFAULT GETUTCDATE(),
    CreatedAt DATETIME NOT NULL DEFAULT GETUTCDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- Create indexes for better performance
CREATE INDEX IX_Users_Username ON Users(Username) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_BookedByUserId ON BookingDetails(BookedByUserId) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_PNR ON BookingDetails(PNR) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_PassengerId ON BookingDetails(PassengerId) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_Status ON BookingDetails(Status) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_BookingDate ON BookingDetails(BookingDate) WHERE DeletedAt IS NULL;
CREATE INDEX IX_ActivityLogs_UserId ON ActivityLogs(UserId);
CREATE INDEX IX_ActivityLogs_Timestamp ON ActivityLogs(Timestamp);
CREATE INDEX IX_BookingStops_BookingId ON BookingStops(BookingId);
GO

-- Insert initial admin user only
-- Default password: "admin123" (hashed with bcrypt)
INSERT INTO Users (
    Username, 
    PasswordHash, 
    Role, 
    FirstName, 
    LastName, 
    Balance, 
    IsLocked,
    CreatedAt,
    UpdatedAt
) VALUES (
    'admin', 
    '$2a$11$2nRZ7rE6QOYkzZq.3YVQJ.DRfz7wW7cXoJk9ZJt8Nv1dLm1Yf9QO2', 
    0, 
    'System', 
    'Admin', 
    0, 
    0,
    GETUTCDATE(),
    GETUTCDATE()
);
GO

PRINT 'Database initialization completed successfully. All tables are empty except for the initial admin user.';
GO