CREATE DATABASE FastFoodStore;
GO

USE FastFoodStore;
GO

-- Tạo bảng Users
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Role NVARCHAR(50) DEFAULT 'Customer',
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Products
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Price DECIMAL(10,2) NOT NULL,
    ImageUrl NVARCHAR(200),
    StockQuantity INT DEFAULT 0,
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Tạo bảng Categories
CREATE TABLE Categories (
    CategoryId INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500)
);

-- Tạo bảng ProductCategories
CREATE TABLE ProductCategories (
    ProductCategoryId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    CategoryId INT NOT NULL,
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
    FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);

-- Tạo bảng Orders
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(10,2) NOT NULL,
    Status NVARCHAR(50) DEFAULT 'Pending',
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Tạo bảng OrderDetails
CREATE TABLE OrderDetails (
    OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

-- Tạo bảng Combos
CREATE TABLE Combos (
    ComboId INT IDENTITY(1,1) PRIMARY KEY,
    ComboName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500),
    Price DECIMAL(10,2) NOT NULL,
    ImageUrl NVARCHAR(200),
    CreatedDate DATETIME DEFAULT GETDATE()
);

-- Tạo bảng ComboDetails
CREATE TABLE ComboDetails (
    ComboDetailId INT IDENTITY(1,1) PRIMARY KEY,
    ComboId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL,
    FOREIGN KEY (ComboId) REFERENCES Combos(ComboId),
    FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);
GO

-- Chèn dữ liệu mẫu vào bảng Users
INSERT INTO Users (FullName, Email, Password, PhoneNumber, Role)
VALUES 
('Nguyen Van A', 'user1@example.com', 'password123', '0123456789', 'Customer'),
('Tran Thi B', 'user2@example.com', 'password123', '0987654321', 'Customer'),
('Admin User', 'admin@example.com', 'admin123', '0111222333', 'Admin');

-- Chèn dữ liệu mẫu vào bảng Products
INSERT INTO Products (ProductName, Description, Price, ImageUrl, StockQuantity)
VALUES 
('Burger', 'Delicious beef burger', 50.00, 'burger.jpg', 100),
('Fries', 'Crispy french fries', 20.00, 'fries.jpg', 200),
('Cola', 'Refreshing cola drink', 10.00, 'cola.jpg', 300);

-- Chèn dữ liệu mẫu vào bảng Categories
INSERT INTO Categories (CategoryName, Description)
VALUES 
('Main Dish', 'Primary dishes in the menu'),
('Side Dish', 'Side dishes to complement main dishes'),
('Drinks', 'Beverages');

-- Chèn dữ liệu mẫu vào bảng ProductCategories
INSERT INTO ProductCategories (ProductId, CategoryId)
VALUES 
(1, 1), -- Burger belongs to Main Dish
(2, 2), -- Fries belongs to Side Dish
(3, 3); -- Cola belongs to Drinks

-- Chèn dữ liệu mẫu vào bảng Orders
INSERT INTO Orders (UserId, TotalAmount, Status)
VALUES 
(1, 80.00, 'Completed'),
(2, 50.00, 'Pending'),
(1, 60.00, 'Cancelled');

-- Chèn dữ liệu mẫu vào bảng OrderDetails
INSERT INTO OrderDetails (OrderId, ProductId, Quantity, Price)
VALUES 
(1, 1, 1, 50.00), -- 1 Burger
(1, 2, 1, 20.00), -- 1 Fries
(2, 3, 5, 10.00); -- 5 Cola

-- Chèn dữ liệu mẫu vào bảng Combos
INSERT INTO Combos (ComboName, Description, Price, ImageUrl)
VALUES 
('Family Combo', 'Perfect for family', 120.00, 'family_combo.jpg'),
('Friends Combo', 'Great for a group of friends', 150.00, 'friends_combo.jpg'),
('Budget Combo', 'Affordable and delicious', 90.00, 'budget_combo.jpg');

-- Chèn dữ liệu mẫu vào bảng ComboDetails
INSERT INTO ComboDetails (ComboId, ProductId, Quantity)
VALUES 
(1, 1, 2), -- Family Combo includes 2 Burgers
(1, 2, 2), -- Family Combo includes 2 Fries
(2, 3, 5); -- Friends Combo includes 5 Cola


