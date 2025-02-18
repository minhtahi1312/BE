CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL,
    role VARCHAR(50) CHECK (role IN ('Cyclist', 'Shop Owner', 'Admin')) NOT NULL,
    contact_info VARCHAR(255),
    profile_picture_url VARCHAR(255),
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE Shops (
    shop_id INT IDENTITY(1,1) PRIMARY KEY,
    owner_id INT,
    name VARCHAR(255) NOT NULL,
    address VARCHAR(255) NOT NULL,
    contact_info VARCHAR(255),
    operating_hours VARCHAR(255),
    profile_picture_url VARCHAR(255),
    FOREIGN KEY (owner_id) REFERENCES Users(user_id)
);

CREATE TABLE Items (
    item_id INT IDENTITY(1,1) PRIMARY KEY,
    shop_id INT,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    price DECIMAL(10, 2) NOT NULL,
    stock INT DEFAULT 0,  -- Chỉ áp dụng cho sản phẩm
    duration INT DEFAULT 0,  -- Chỉ áp dụng cho dịch vụ
    item_type VARCHAR(50) CHECK (item_type IN ('Product', 'Service')) NOT NULL, -- Phân biệt sản phẩm và dịch vụ
    FOREIGN KEY (shop_id) REFERENCES Shops(shop_id)
);

CREATE TABLE Bookings (
    booking_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    shop_id INT,
    item_id INT,
    transaction_date DATETIME DEFAULT GETDATE(),
    amount DECIMAL(10, 2) NOT NULL,
    transaction_type VARCHAR(50) CHECK (transaction_type IN ('Purchase', 'Booking')) NOT NULL,
    status VARCHAR(50) CHECK (status IN ('Completed', 'Failed', 'Pending')) DEFAULT 'Pending',
    item_type VARCHAR(50) CHECK (item_type IN ('Product', 'Service')) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (shop_id) REFERENCES Shops(shop_id),
    FOREIGN KEY (item_id) REFERENCES Items(item_id)
);

CREATE TABLE GroupRides (
    ride_id INT IDENTITY(1,1) PRIMARY KEY,
    match_name VARCHAR(255) NOT NULL,
    start_time DATETIME NOT NULL,
    start_location VARCHAR(255) NOT NULL,
    password VARCHAR(255),  -- Optional password for joining
    created_by INT,
    FOREIGN KEY (created_by) REFERENCES Users(user_id)
);

CREATE TABLE RideParticipants (
    participant_id INT IDENTITY(1,1) PRIMARY KEY,
    ride_id INT,
    user_id INT,
    joined_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ride_id) REFERENCES GroupRides(ride_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE Routes (
    route_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    route_name VARCHAR(255) NOT NULL,
    description TEXT,
    start_location VARCHAR(255),
    end_location VARCHAR(255),
    distance DECIMAL(10, 2),
    difficulty_level VARCHAR(50) CHECK (difficulty_level IN ('Easy', 'Medium', 'Hard')),
    route_data NVARCHAR(MAX),  -- Store GPS data in JSON format (NVARCHAR(MAX) for SQL Server)
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE Blogs (
    blog_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    title VARCHAR(255) NOT NULL,
    content TEXT NOT NULL,
    category VARCHAR(50) CHECK (category IN ('Cycling Tips', 'Routes', 'Gear Reviews', 'Personal Experiences')),
    tags VARCHAR(255),  -- Tags dưới dạng chuỗi phân cách bằng dấu phẩy
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE BlogComments (
    comment_id INT IDENTITY(1,1) PRIMARY KEY,
    blog_id INT,
    user_id INT,
    comment_text TEXT NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (blog_id) REFERENCES Blogs(blog_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE ShopReviews (
    review_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    shop_id INT,
    rating INT CHECK (rating >= 1 AND rating <= 5),
    review_text TEXT,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (shop_id) REFERENCES Shops(shop_id)
);

CREATE TABLE WeatherAlerts (
    alert_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    alert_type VARCHAR(50) CHECK (alert_type IN ('Rain', 'Snow', 'Wind', 'Temperature')),
    alert_description TEXT,
    alert_time DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE Notifications (
    notification_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    notification_type VARCHAR(50) CHECK (notification_type IN ('Reminder', 'Alert', 'Weather', 'Message')) NOT NULL,
    message TEXT NOT NULL,
    status VARCHAR(50) CHECK (status IN ('Unread', 'Read')) DEFAULT 'Unread',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

CREATE TABLE Reports (
    report_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    shop_id INT,
    report_type VARCHAR(50) CHECK (report_type IN ('Dispute', 'Abuse', 'Spam')),
    description TEXT NOT NULL,
    status VARCHAR(50) CHECK (status IN ('Pending', 'Resolved', 'Closed')) DEFAULT 'Pending',
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (shop_id) REFERENCES Shops(shop_id)
);
CREATE TABLE UserActivity (
    activity_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT,
    activity_type VARCHAR(50),  -- Loại hoạt động (Join Ride, Post Blog, Purchase Product, etc.)
    activity_details TEXT,  -- Chi tiết hoạt động
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);
