Create DATABASE RentCar
--------------------------

CREATE TABLE Clinet(
ClinetId  int PRIMARY KEY IDENTITY(1,1),
userName NVARCHAR(max) NOT NULL,
Email NVARCHAR(max) ,
[Password] NVARCHAR(max) ,
Moblie int NOT NULL ,
Adress NVARCHAR(max) NULL
)

CREATE TABLE Car(
CarId int NOT NULL PRIMARY KEY IDENTITY(1,1),
Compny NVARCHAR(max),
Model NVARCHAR(max),
[Type] NVARCHAR(50),
[Year] int,
Color NVARCHAR(max),
DailyRentPrice int,
[Categoryname] [nvarchar](max) NULL
);

create table Location (
CityId int Primary Key IDENTITY(1,1) ,
CityName nvarchar(Max) Not Null,
NumberOfCars int 
);

create table Inventory(
CarUniqeId int primary key IDENTITY(1,1),
CarId int  Not Null foreign key references Car(CarId) ,
CityId int  Not Null foreign key references Location(CityId) ,
[Availability] Bit  Not Null,
AvailabilDate Date,

);
create table Payment(
PaymentId int primary key IDENTITY(1,1) ,
CardNumber bigint Not Null ,
CardExpirDate Date Not Null,
NameCard nvarchar(max) Not Null,
PaymentType nvarchar(max) Not Null,
BankName nvarchar(max) NULL,
ClinetId int  Not Null foreign key references Clinet(ClinetId) 
);

create table Orders(
OrderId int Primary Key IDENTITY(1,1) NOT NULL,
Statue nvarchar(max),
PaymentId int  NOT NULL foreign key references Payment(PaymentId)  ,
FromDate Date,
ToDate Date,
OrderSubmitDate Date,
SouresAddress int NULL,
DestinationAddress [nvarchar](max) NULL,
CarId [int] NULL foreign key references Car(CarId),
ClientId int NULL foreign key references Clinet(ClinetId) 
);

create table History(
HistoryID int primary key IDENTITY(1,1),
StartDate Date ,
FinshDate Date ,
CarUniqeId int  Not Null  foreign key references Car(CarId) ,
DistanceTraveledInKilo int  Not Null

);




