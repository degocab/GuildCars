use GuildCars
go



IF EXISTS(SELECT * FROM sys.tables WHERE name='Sale')
	DROP TABLE Sale
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Vehicle')
	DROP TABLE Vehicle
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='States')
	DROP TABLE States
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='InteriorColor')
	DROP TABLE InteriorColor
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='ExteriorColor')
	DROP TABLE ExteriorColor
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Model')
	DROP TABLE Model
GO
IF EXISTS(SELECT * FROM sys.tables WHERE name='Make')
	DROP TABLE Make
GO


IF EXISTS(SELECT * FROM sys.tables WHERE name='Specials')
	DROP TABLE Specials
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='PurchaseType')
	DROP TABLE PurchaseType
GO





create table States(
	StateId int identity(1,1) primary key,
	StateAbbrevation varchar(2) not null,
)
go


create table Specials(
	SpecialsId int identity(1,1) primary key,
	Title varchar(30) not null,
	Description varchar(120) not null
)
go
create table InteriorColor(
	InteriorColorId int identity(1,1) primary key,
	IColor varchar(30) not null
)
GO
create table ExteriorColor(
	ExteriorColorId int identity(1,1) primary key,
	EColor varchar(30) not null
)
GO
create table PurchaseType(
	PurchaseTypeId int identity(1,1) primary key,
	Type varchar(30) not null
)
GO
create table Make(
	MakeId int identity(1,1) primary key,
	Make varchar(30) not null
)
go

create table Model(
	ModelId int identity(1,1) primary key,
	Model varchar(30) not null,
	MakeId int not null
	foreign key(MakeId) references Make(MakeId) 
)
go

create table Vehicle(
	VehicleId int identity(1,1) primary key,
	ExteriorColorId int not null,
	InteriorColorId int not null,
	constraint FK_Vehicle_ExteriorColorId
	foreign key (ExteriorColorId) references ExteriorColor(ExteriorColorId),
	constraint FK_Vehicle_InteriorColorId
	foreign key (InteriorColorId) references InteriorColor(InteriorColorId),
	ModelId int foreign key references Model(ModelId) not null,
	Price decimal(8,2) not null,
	Year int not null,
	DateAdded date not null,
	Transmission varchar(30) not null,
	BodyStyle varchar(30) not null,
	Mileage varchar(30) not null,
	VIN varchar(17) not null,
	MSRP decimal(8,2) not null,
	Description varchar(256) not null,
	Condition bit not null,
	Featured bit not null,
	Picture varchar(max) not null

	--for use with asp.net identity
	--UserId int foreign key references User(UserId) not null
)
go


create table Sale(
	SaleId int identity(1,1) primary key,
	Name varchar(30) not null,
	Phone varchar(12) not null,
	Email varchar(30) not null,
	Street1 varchar(30) not null,
	Street2 varchar(30)  null,
	City varchar(30) not null,
	Zipcode varchar(5) not null,
	StateId int not null,
	foreign key (StateId) references States(StateId),
	PurchasedPrice decimal(8,2) not null,
	PurchaseTypeId int foreign key references PurchaseType(PurchaseTypeId) not null,
	VehicleId int foreign key references Vehicle(VehicleId) not null,
	SaleDate date not null,

	--for use with asp.net identity
	--UserId int foreign key references User(UserId) not null
)
go
