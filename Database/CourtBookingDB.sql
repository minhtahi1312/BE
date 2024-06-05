<<<<<<< HEAD

CREATE DATABASE CourtBookingDB;
USE CourtBookingDB;

-- Create User table
CREATE TABLE [User] (
    User_ID NVARCHAR(30) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20) NOT NULL UNIQUE,
    Address NVARCHAR(255),
    Birthday DATE,
    Gender BIT,
    isActive BIT NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);

-- Create CourtCluster table
CREATE TABLE CourtCluster (
    CourtCluster_ID NVARCHAR(30) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    Description NVARCHAR(255),
    Status NVARCHAR(50) NOT NULL,
    Location NVARCHAR(255) NOT NULL,
    Image NVARCHAR(255),
    User_ID NVARCHAR(30) NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES [User](User_ID) ON DELETE CASCADE
);

-- Create Court table
CREATE TABLE Court (
    Court_ID NVARCHAR(30) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255),
    CourtCluster_ID NVARCHAR(30) NOT NULL,
    FOREIGN KEY (CourtCluster_ID) REFERENCES CourtCluster(CourtCluster_ID) ON DELETE CASCADE
);

-- Create Slot table
CREATE TABLE Slot (
    Slot_ID INT PRIMARY KEY,
    Date DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Court_ID NVARCHAR(30) NOT NULL,
    FOREIGN KEY (Court_ID) REFERENCES Court(Court_ID) ON DELETE CASCADE
);

-- Create Customer table
CREATE TABLE Customer (
    Customer_ID NVARCHAR(30) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(20) NOT NULL UNIQUE,
    Address NVARCHAR(255),
    Birthday DATE,
    Gender CHAR(1),
    isActive BIT NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(50) NOT NULL
);

-- Create Wallet table
CREATE TABLE Wallet (
    Wallet_ID NVARCHAR(30) PRIMARY KEY,
    Customer_ID NVARCHAR(30) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID) ON DELETE CASCADE
);

-- Create Deposit table
CREATE TABLE Deposit (
    Deposit_ID NVARCHAR(30) PRIMARY KEY,
    Customer_ID NVARCHAR(30) NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    VNPayCode NVARCHAR(50) NOT NULL UNIQUE,
    Time DATETIME NOT NULL,
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID) ON DELETE CASCADE
);

-- Create Booking table
CREATE TABLE Booking (
    Booking_ID NVARCHAR(30) PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL UNIQUE,
    Status NVARCHAR(50) NOT NULL,
    Created_at DATETIME NOT NULL,
    Customer_ID NVARCHAR(30) NOT NULL,
    CourtCluster_ID NVARCHAR(30) NOT NULL,
    FromTime DATETIME NOT NULL,
    ToTime DATETIME NOT NULL,
    FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID) ON DELETE CASCADE,
    FOREIGN KEY (CourtCluster_ID) REFERENCES CourtCluster(CourtCluster_ID) ON DELETE CASCADE
);

-- Create BookingDetail table
CREATE TABLE BookingDetail (
    BookingDetail_ID NVARCHAR(30) PRIMARY KEY,
    Booking_ID NVARCHAR(30) NOT NULL,
    Slot_ID INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (Booking_ID) REFERENCES Booking(Booking_ID) ON DELETE CASCADE,
    FOREIGN KEY (Slot_ID) REFERENCES Slot(Slot_ID) 
);

-- Create Transaction table
CREATE TABLE [Transaction] (
    Transaction_ID NVARCHAR(30) PRIMARY KEY,
    TotalSlot INT NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Booking_ID NVARCHAR(30) NOT NULL,
    Wallet_ID NVARCHAR(30) NOT NULL,
    Deposit_ID NVARCHAR(30) NOT NULL,
    FOREIGN KEY (Booking_ID) REFERENCES Booking(Booking_ID) ON DELETE CASCADE,
    FOREIGN KEY (Wallet_ID) REFERENCES Wallet(Wallet_ID),
    FOREIGN KEY (Deposit_ID) REFERENCES Deposit(Deposit_ID) 
);

USE CourtBookingDB;

-- Insert data into User table
INSERT INTO [User] (User_ID, Name, Email, Phone, Address, Birthday, Gender, isActive, Role, Username, Password)
VALUES 
('U001', 'John Doe', 'johndoe@example.com', '1234567890', '123 Main St', '1985-05-15', 1, 1, 'Admin', 'johndoe', 'password1'),
('U002', 'Jane Smith', 'janesmith@example.com', '0987654321', '456 Elm St', '1990-10-20', 0, 1, 'Manager', 'janesmith', 'password2');

-- Insert data into Customer table
INSERT INTO Customer (Customer_ID, Name, Email, Phone, Address, Birthday, Gender, isActive, Username, Password)
VALUES 
('C001', 'Alice Johnson', 'alicej@example.com', '1122334455', '789 Oak St', '1992-02-25', 'F', 1, 'alicej', 'password3'),
('C002', 'Bob Brown', 'bobb@example.com', '5544332211', '321 Pine St', '1988-08-12', 'M', 1, 'bobb', 'password4');

-- Insert data into CourtCluster table
INSERT INTO CourtCluster (CourtCluster_ID, Name, Price, Description, Status, Location, Image, User_ID)
VALUES 
('CC001', 'Central Park Courts', 50.00, 'Courts at Central Park', 'Available', 'Central Park, NYC', 'image1.jpg', 'U001'),
('CC002', 'Westside Courts', 40.00, 'Courts at Westside', 'Available', 'Westside, NYC', 'image2.jpg', 'U002');

-- Insert data into Court table
INSERT INTO Court (Court_ID, Name, Status, Description, CourtCluster_ID)
VALUES 
('CT001', 'Court 1', 'Available', 'First court', 'CC001'),
('CT002', 'Court 2', 'Available', 'Second court', 'CC001'),
('CT003', 'Court A', 'Available', 'First court in Westside', 'CC002');

-- Insert data into Slot table
INSERT INTO Slot (Slot_ID, Date, StartTime, EndTime, Court_ID)
VALUES 
(1, '2024-06-10', '08:00', '09:00', 'CT001'),
(2, '2024-06-10', '09:00', '10:00', 'CT001'),
(3, '2024-06-10', '08:00', '09:00', 'CT002');

-- Insert data into Wallet table
INSERT INTO Wallet (Wallet_ID, Customer_ID, Amount)
VALUES 
('W001', 'C001', 100.00),
('W002', 'C002', 50.00);

-- Insert data into Deposit table
INSERT INTO Deposit (Deposit_ID, Customer_ID, Amount, VNPayCode, Time)
VALUES 
('D001', 'C001', 50.00, 'VN123456', '2024-06-01 10:00:00'),
('D002', 'C002', 30.00, 'VN654321', '2024-06-02 11:00:00');

-- Insert data into Booking table
INSERT INTO Booking (Booking_ID, Code, Status, Created_at, Customer_ID, CourtCluster_ID, FromTime, ToTime)
VALUES 
('B001', 'BK12345', 'Confirmed', '2024-06-03 09:00:00', 'C001', 'CC001', '2024-06-10 08:00:00', '2024-06-10 10:00:00'),
('B002', 'BK54321', 'Confirmed', '2024-06-04 10:00:00', 'C002', 'CC001', '2024-06-10 09:00:00', '2024-06-10 10:00:00');

-- Insert data into BookingDetail table
INSERT INTO BookingDetail (BookingDetail_ID, Booking_ID, Slot_ID, Price)
VALUES 
('BD001', 'B001', 1, 50.00),
('BD002', 'B001', 2, 50.00),
('BD003', 'B002', 2, 40.00);

-- Insert data into Transaction table
INSERT INTO [Transaction] (Transaction_ID, TotalSlot, TotalPrice, Status, Booking_ID, Wallet_ID, Deposit_ID)
VALUES 
('T001', 2, 100.00, 'Completed', 'B001', 'W001', 'D001'),
('T002', 1, 40.00, 'Completed', 'B002', 'W002', 'D002');

