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
    LockoutEnd DATETIME
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
    DeletedAt DATETIME
);
GO


-- Create Flights table
CREATE TABLE Flights (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FlightNumber NVARCHAR(20) NOT NULL,
    Airline NVARCHAR(50) NOT NULL,
    Duration TIME NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    SeatClass NVARCHAR(20) NOT NULL,
    DestinationImageUrl NVARCHAR(255),
    AirlineLogoUrl NVARCHAR(255),
    Origin NVARCHAR(50) NOT NULL,
    Destination NVARCHAR(50) NOT NULL,
    DepartureTime DATETIME NOT NULL,
    ArrivalTime DATETIME NOT NULL,
    Stops INT NOT NULL DEFAULT 0
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
    FOREIGN KEY (PassengerId) REFERENCES Passengers(Id),
    FOREIGN KEY (BookedByUserId) REFERENCES Users(Id)
);
GO

-- Insert initial admin user
-- Default password: "admin123" (you should change this in production)
INSERT INTO Users (Username, PasswordHash, Role, FirstName, LastName, Balance, IsLocked)
VALUES ('admin', '$2a$11$2nRZ7rE6QOYkzZq.3YVQJ.DRfz7wW7cXoJk9ZJt8Nv1dLm1Yf9QO2', 0, 'System', 'Admin', 0, 0);
GO


-- Create indexes for better performance
CREATE INDEX IX_Users_Username ON Users(Username) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_BookedByUserId ON BookingDetails(BookedByUserId) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_PNR ON BookingDetails(PNR) WHERE DeletedAt IS NULL;
CREATE INDEX IX_BookingDetails_PassengerId ON BookingDetails(PassengerId) WHERE DeletedAt IS NULL;
GO

-- Create stored procedure for user authentication
CREATE PROCEDURE sp_AuthenticateUser
    @Username NVARCHAR(50),
    @Password NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    
    DECLARE @UserId INT;
    DECLARE @PasswordHash NVARCHAR(255);
    DECLARE @IsLocked BIT;
    DECLARE @LockoutEnd DATETIME;
    DECLARE @FailedAttempts INT;
    
    -- Get user data
    SELECT 
        @UserId = Id,
        @PasswordHash = PasswordHash,
        @IsLocked = IsLocked,
        @LockoutEnd = LockoutEnd,
        @FailedAttempts = FailedLoginAttempts
    FROM Users 
    WHERE Username = @Username AND DeletedAt IS NULL;
    
    -- Check if user exists
    IF @UserId IS NULL
    BEGIN
        SELECT 
            'Success' = 0,
            'Message' = 'Username not found.';
        RETURN;
    END
    
    -- Check if account is locked
    IF @IsLocked = 1 AND @LockoutEnd > GETUTCDATE()
    BEGIN
        SELECT 
            'Success' = 0,
            'Message' = CONCAT('Account is temporarily locked. Please try again after ', 
                             DATEDIFF(SECOND, GETUTCDATE(), @LockoutEnd), ' seconds.');
        RETURN;
    END
    
    -- Verify password (in a real system, you'd use proper password hashing verification)
    IF @PasswordHash != HASHBYTES('SHA2_256', @Password)
    BEGIN
        -- Increment failed attempts
        SET @FailedAttempts = @FailedAttempts + 1;
        UPDATE Users 
        SET FailedLoginAttempts = @FailedAttempts
        WHERE Id = @UserId;
        
        -- Lock account if too many attempts
        IF @FailedAttempts >= 5
        BEGIN
            UPDATE Users 
            SET IsLocked = 1,
                LockoutEnd = DATEADD(MINUTE, 1, GETUTCDATE())
            WHERE Id = @UserId;
            
            SELECT 
                'Success' = 0,
                'Message' = 'Too many failed attempts. Account locked for 1 minute.';
            RETURN;
        END
        
        SELECT 
            'Success' = 0,
            'Message' = CONCAT('Invalid password. ', (5 - @FailedAttempts), ' attempts remaining.');
        RETURN;
    END
    
    -- Successful login - reset attempts and update last login
    UPDATE Users 
    SET FailedLoginAttempts = 0,
        IsLocked = 0,
        LockoutEnd = NULL,
        LastLogin = GETUTCDATE()
    WHERE Id = @UserId;
    
    -- Return user data
    SELECT 
        'Success' = 1,
        'Message' = 'Authentication successful.',
        'Id' = Id,
        'Username' = Username,
        'Role' = Role,
        'FirstName' = FirstName,
        'LastName' = LastName,
        'Balance' = Balance
    FROM Users
    WHERE Id = @UserId;
END
GO


PRINT 'Database initialization completed successfully.';
GO
