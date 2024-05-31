-- Table to store user(customer/court owner/admin) information
CREATE TABLE [User] (
    User_ID NVARCHAR PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(15),
    Address NVARCHAR(255),
    Birthday DATE,
    Gender NVARCHAR(10),
    isActive BIT DEFAULT 1,
    Role NVARCHAR(50),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,  -- Ensure this is stored as a hash
);


-- Table to store information about court clusters
CREATE TABLE CourtCluster (
    CourtCluster_ID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(255),
    Status NVARCHAR(50) NOT NULL,
    Location NVARCHAR(255),
    Image NVARCHAR(255),
    User_ID NVARCHAR NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES [User](User_ID) ON DELETE CASCADE
);

-- Table to store information about courts
CREATE TABLE Court (
    Court_ID NVARCHAR PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255),
    CourtCluster_ID INT NOT NULL,
    FOREIGN KEY (CourtCluster_ID) REFERENCES CourtCluster(CourtCluster_ID) ON DELETE CASCADE
);

-- Table to store information about time slots for booking
CREATE TABLE Slot (
    Slot_ID INT PRIMARY KEY,
    Date DATE NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NOT NULL,
    Court_ID NVARCHAR NOT NULL,
    FOREIGN KEY (Court_ID) REFERENCES Court(Court_ID) ON DELETE CASCADE
);

-- Table to store booking information
CREATE TABLE Booking (
    Booking_ID INT PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Created_at DATETIME DEFAULT GETDATE(),
    User_ID NVARCHAR NOT NULL,
    CourtCluster_ID INT NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES [User](User_ID) ON DELETE CASCADE,
    FOREIGN KEY (CourtCluster_ID) REFERENCES CourtCluster(CourtCluster_ID)
);

-- Table to store details of each booking
CREATE TABLE BookingDetail (
    BookingDetail_ID INT PRIMARY KEY,
    Booking_ID INT NOT NULL,
    Slot_ID INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (Booking_ID) REFERENCES Booking(Booking_ID),
    FOREIGN KEY (Slot_ID) REFERENCES Slot(Slot_ID) 
);

-- Table to store wallet information for customers
CREATE TABLE Wallet (
    Wallet_ID INT PRIMARY KEY,
    User_ID NVARCHAR NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (User_ID) REFERENCES [User](User_ID) ON DELETE CASCADE
);

-- Table to store deposit transactions for customers
CREATE TABLE Deposit (
    Deposit_ID INT PRIMARY KEY,
    User_ID NVARCHAR NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    VNPayCode NVARCHAR(50) NOT NULL,
    Time DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (User_ID) REFERENCES [User](User_ID) ON DELETE CASCADE
);

-- Table to store transactions related to bookings
CREATE TABLE [Transaction] (
    Transaction_ID INT PRIMARY KEY,
    TotalSlot INT NOT NULL,
    TotalPrice DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(50) NOT NULL,
    Booking_ID INT NOT NULL,
    FOREIGN KEY (Booking_ID) REFERENCES Booking(Booking_ID) ON DELETE CASCADE
);
