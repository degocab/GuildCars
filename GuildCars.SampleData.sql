use GuildCars
go	
--IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
--	WHERE ROUTINE_NAME = 'DbReset')
--		DROP PROCEDURE DbReset
--GO

--CREATE PROCEDURE DbReset AS
--BEGIN
--exec DbReset

Delete From Sale;
Delete From Vehicle;
Delete From ExteriorColor;
Delete From InteriorColor;
Delete From PurchaseType;
Delete From Model;
Delete From Make;
Delete From States;
Delete From Specials;

dbcc checkident ('States',reseed,1)
dbcc checkident ('ExteriorColor',reseed,1)
dbcc checkident ('InteriorColor',reseed,1)
dbcc checkident ('PurchaseType',reseed,1)
dbcc checkident ('Model',reseed,1)
dbcc checkident ('Make',reseed,1)
dbcc checkident ('Vehicle',reseed,1)
dbcc checkident ('Sale',reseed,1)
dbcc checkident ('Specials',reseed,1)


SET IDENTITY_INSERT States ON;


insert into States(StateId, StateAbbrevation)
values(1,'AL'),
(2,'AK'),
(3,'AZ'),
(4,'AR'),
(5,'CA'),
(6,'CO'),
(7,'CT'),
(8,'DE'),
(9,'FL'),
(10,'GA'),
(11,'HI'),
(12,'ID'),
(13,'IL'),
(14,'IN'),
(15,'IA'),
(16,'KS'),
(17,'KY'),
(18,'LA'),
(19,'ME'),
(20,'MD'),
(21,'MA'),
(22,'MI'),
(23,'MN'),
(24,'MS'),
(25,'MO'),
(26,'MT'),
(27,'NE'),
(28,'NV'),
(29,'NH'),
(30,'NJ'),
(31,'NM'),
(32,'NY'),
(33,'NC'),
(34,'ND'),
(35,'OH'),
(36,'OK'),
(37,'OR'),
(38,'PA'),
(39,'RI'),
(40,'SC'),
(41,'SD'),
(42,'TN'),
(43,'TX'),
(44,'UT'),
(45,'VT'),
(46,'VA'),
(47,'WA'),
(48,'WV'),
(49,'WI'),
(50,'WY')

SET IDENTITY_INSERT States off;

SET IDENTITY_INSERT ExteriorColor ON;
insert into ExteriorColor(ExteriorColorId, EColor)
values(1,'Red'),
(2,'Black'),
(3,'White'),
(4,'Blue'),
(5,'Silver'),
(6,'Green')

SET IDENTITY_INSERT ExteriorColor off;

SET IDENTITY_INSERT InteriorColor ON;
insert into InteriorColor(InteriorColorId, IColor)
values(1,'Red'),
(2,'Black'),
(3,'White'),
(4,'Blue'),
(5,'Silver'),
(6,'Green'),
(7,'Grey')

SET IDENTITY_INSERT InteriorColor off;


set identity_insert PurchaseType on;
insert into PurchaseType(PurchaseTypeId,Type)
values(1,'Bank Finance'),
(2,'Cash'),
(3,'Dealer Finance')
set identity_insert PurchaseType off;

set identity_insert Make on;
insert into Make(MakeId,Make)
values(1,'BMW'),
(2,'Toyota'),
(3,'Honda'),
(4,'Ford')
set identity_insert Make off;

set identity_insert Model on;
insert into Model(ModelId,Model,MakeId)
values(1,'740i xDrive',1),
(2,'Corolla SE',2),
(3,'Pilot Touring',3),
(4,'Mustang Shelby GT350',4)
set identity_insert Model off;


set identity_insert Vehicle on;
insert into Vehicle(VehicleId,ExteriorColorId,InteriorColorId,ModelId,Price,Year,DateAdded,Transmission,BodyStyle,Mileage,VIN,MSRP,Description, Condition,Featured,Picture)
values(1,5,2,1,99040.00,2018,'1/1/2000','Automatic','Car','0','AS9D8F7AS8F79ASDF',99400.00,'Sunroof, Heated Leather Seats, NAV, Back-Up Camera, Rear Air, All Wheel Drive, M SPORT PACKAGE.',1,1,'/Content/Images/inventory-1.png'),
(2,1,2,2,23500.00,2018,'1/1/2000','Automatic','Car','0','A8SADFCD9ASDF8SD9',23500.00,'Cool red car for sale',1,1,'/Content/Images/inventory-2.png'),
(3,2,2,3,38500.00,2018,'1/1/2000','Automatic','SUV','0','ASDKJFASDC98ADS73',38500,'Cool black car',1,1,'/Content/Images/inventory-3.png'),
(4,4,2,4,65500.00,2017,'1/1/2017','Manual','Car','0','ASDF9AS8DCD7UJ477',65500.00,'Blue mustang',1,1,'/Content/Images/inventory-4.png'),
(5,5,2,4,58500.00,2017,'1/1/2017','Manual','Car','22,000','ASDLFJASDLKCMN453',58500.00,'Silver mustang',0,1,'/Content/Images/inventory-5.png')
set identity_insert Vehicle off;


set identity_insert Sale on;
insert into Sale(SaleId, Name,Phone,Email,Street1,Street2,City,Zipcode,StateId,PurchasedPrice,PurchaseTypeId,VehicleId,SaleDate)
values(1,'Randal','000000000000','randall@randall.com','100 Randall St',null,'Randall City','00000',35,80000,2,4,'1/1/2017'),
(2,'NotRandal','000000000001','notrandall@randall.com','101 Randall St',null,'Randall City','00000',35,99990,2,4,'1/1/2017'),
(3,'NotRandal','000000000001','notrandall@randall.com','101 Randall St',null,'Randall City','00000',35,99990,2,4,'1/1/2018')
set identity_insert Sale off;

set identity_insert Specials on;
insert into Specials(SpecialsId, Title, Description)
values(1,'Free','Free cars, just use coupon'),
(2,'Double Price','Pay one for the double the price'),
(3,'Triple Price','Pay one for triple the price')

set identity_insert Specials off;

--end
--go

