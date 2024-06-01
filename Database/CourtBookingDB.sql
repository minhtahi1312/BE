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
