CREATE DATABASE [RailwayStationDB]

CREATE TABLE [Trains](
[TrainId] INT PRIMARY KEY IDENTITY (1,1),
[TrainNumber] VARCHAR (10) UNIQUE,
[Capacity] INT
) 

CREATE TABLE [Routes](
[RouteId] INT PRIMARY KEY IDENTITY (1,1),
[TrainId] INT FOREIGN KEY REFERENCES Trains(TrainId),
[DepartureStation] VARCHAR (100),
[ArrivalStation] VARCHAR (100),
[DepartureTime] DATETIME,
[ArrivalTime] DATETIME
)

CREATE TABLE [Tracks](
[TrackId] INT PRIMARY KEY IDENTITY (1,1),
[StationName] VARCHAR (100),
[TrackNumber] INT UNIQUE,
[TrainId] INT FOREIGN KEY REFERENCES Trains(TrainId)
)

CREATE TABLE [Tickets](
[TicketId] INT PRIMARY KEY IDENTITY (1,1),
[PassengerName] VARCHAR (100),
[TraindId] INT FOREIGN KEY REFERENCES Trains(TrainId),
[RouteId] INT FOREIGN KEY REFERENCES Routes(RouteId),
[SeatNumber] VARCHAR (10),
[Price] DECIMAL (10,2)
)

CREATE TABLE [Employees](
[EmployeeId] INT PRIMARY KEY IDENTITY (1,1),
[Name] VARCHAR (100),
[Position] VARCHAR (50),
[TrainId] INT FOREIGN KEY REFERENCES Trains(TrainId)
)

INSERT INTO Trains (TrainNumber, Capacity) 
VALUES 
('EXP100', 300), 
('REG200', 150), 
('FRT300', 500);

INSERT INTO Routes (TrainId, DepartureStation, ArrivalStation, DepartureTime, ArrivalTime) 
VALUES 
(1, 'Sofia', 'Varna', '2025-03-16 08:00:00', '2025-03-16 14:30:00'), 
(2, 'Sofia', 'Plovdiv', '2025-03-16 09:30:00', '2025-03-16 11:00:00'), 
(3, 'Burgas', 'Ruse', '2025-03-16 10:00:00', '2025-03-16 18:00:00'); 

INSERT INTO Tracks (StationName, TrackNumber, TrainId) 
VALUES 
('Central Station Sofia', 1, 1), 
('Central Station Sofia', 2, 2), 
('Plovdiv Station', 3, NULL), 
('Varna Station', 4, 3); 

INSERT INTO Tickets (PassengerName, TraindId, RouteId, SeatNumber, Price) 
VALUES 
('John Smith', 1, 1, '12A', 45.50), 
('Emma Johnson', 2, 2, '8B', 15.00), 
('George Brown', 3, 3, '5C', 60.00), 
('Sophia Wilson', 1, 1, '7D', 45.50);

INSERT INTO Employees (Name, Position, TrainId) 
VALUES 
('Michael Davis', 'Train Driver', 1), 
('James Miller', 'Conductor', 2), 
('Robert Taylor', 'Operator', NULL), 
('William Anderson', 'Train Driver', 3); 
