use GuildCars
go

--Makes
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateMake')
	DROP PROCEDURE CreateMake
GO


create procedure CreateMake(
	@MakeId int output,
	@Make varchar(30)
	
)
as
begin
	insert into Make (Make)
	values(@Make)
	set @MakeId = @@IDENTITY;
end
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EditMake')
	DROP PROCEDURE EditMake
GO
create procedure EditMake(
	@MakeId int,
	@Make varchar(30)
)
as 
begin
	update Make set
	Make = @Make
where MakeId = @MakeId
end 
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteMake')
	DROP PROCEDURE DeleteMake
GO
create procedure DeleteMake(
	@MakeId int
)
as
begin
delete from Make 
where MakeId = @MakeId;
end
go

if exists(select* from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetByMakeId')
	drop procedure GetByMakeId
go
create procedure GetByMakeId(
	@MakeId int
)
as 
begin
select * from Make
where MakeId = @MakeId
end
go


if exists(select*from INFORMATION_SCHEMA.ROUTINEs
	where Routine_Name = 'GetAllMakes')
	drop procedure GetAllMakes
go
create procedure GetAllMakes
as
begin
select *
from Make
end 
go
--End MAkes

--Model
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateModel')
	DROP PROCEDURE CreateModel
GO


create procedure CreateModel(
	@ModelId int output,
	@Model varchar(30),
	@MakeId int
	
)
as
begin
	insert into Model (Model,MakeId)
	values(@Model,@MakeId)
	set @ModelId = @@IDENTITY;
end
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EditModel')
	DROP PROCEDURE EditModel
GO
create procedure EditModel(
	@ModelId int,
	@Model varchar(30),
	@MakeId int
)
as 
begin
	update Model set
	Model = @Model,
	MakeId = @MakeId
where ModelId = @ModelId
end 
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteModel')
	DROP PROCEDURE DeleteModel
GO
create procedure DeleteModel(
	@ModelId int
)
as
begin
delete from Model 
where ModelId = @ModelId;
end
go

if exists(select* from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetByModelId')
	drop procedure GetByModelId
go
create procedure GetByModelId(
	@ModelId int,
	@Model varchar(30),
	@MakeId int
)
as 
begin
select * from Model
where ModelId = @ModelId
end
go


if exists(select*from INFORMATION_SCHEMA.ROUTINEs
	where Routine_Name = 'GetAllModels')
	drop procedure GetAllModels
go
create procedure GetAllModels
as
begin
select *
from Model
inner join Make on Model.MakeId= Make.MakeId
end 
go
--end model



--SPECIALS
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateSpecials')
	DROP PROCEDURE CreateSpecials
GO


create procedure CreateSpecials(
	@SpecialsId int output,
	@Title varchar(30),
	@Description varchar(120)
	
)
as
begin
	insert into Specials(SpecialsId,Title,Description)
	values(@SpecialsId,@Title,@Description)
	set @SpecialsId = @@IDENTITY;
end
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EditSpecials')
	DROP PROCEDURE EditSpecials
GO
create procedure EditSpecials(
	@SpecialsId int,
	@Title varchar(30),
	@Description varchar(120)
)
as 
begin
	update Specials set
	Title = @Title,
	Description = @Description
where SpecialsId = @SpecialsId
end 
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteSpecials')
	DROP PROCEDURE DeleteSpecials
GO
create procedure DeleteSpecials(
	@SpecialsId int
)
as
begin
delete from Specials 
where SpecialsId = @SpecialsId;
end
go

if exists(select* from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetBySpecialsId')
	drop procedure GetBySpecialsId
go
create procedure GetBySpecialsId(
	@SpecialsId int,
	@Title varchar(30),
	@Description varchar(120)
)
as 
begin
select * from Specials
where SpecialsId =@SpecialsId
end
go


if exists(select*from INFORMATION_SCHEMA.ROUTINEs
	where Routine_Name = 'GetAllSpecials')
	drop procedure GetAllSpecials
go
create procedure GetAllSpecials
as
begin
select *
from Specials
end 
go
--End Specials



--VEHCILES
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateVehicle')
	DROP PROCEDURE CreateVehicle
GO


create procedure CreateVehicle(
	@VehicleId int output,
	@ExteriorColorId int,
	@InteriorColorId int,
	@ModelId int,
	@Price decimal(8,2),
	@Year int,
	@DateAdded date,
	@Transmission varchar(30),
	@BodyStyle varchar(30),
	@Mileage varchar(30),
	@VIN varchar(17),
	@MSRP decimal(8,2),
	@Description varchar(120),
	@Featured bit,
	@Condition bit,
	@Picture varchar(30)
)
as
begin
	insert into Vehicle(ExteriorColorId,InteriorColorId,ModelId,Price,Year,DateAdded,Transmission,BodyStyle,Mileage,VIN,MSRP,Description,Featured,Condition,Picture)
	values(@ExteriorColorId,@InteriorColorId,@ModelId,@Price,@Year,@DateAdded,@Transmission,@BodyStyle,@Mileage,@VIN,@MSRP,@Description,@Featured,@Condition,@Picture)
	set @VehicleId = @@IDENTITY;
end
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'EditVehicle')
	DROP PROCEDURE EditVehicle
GO
create procedure EditVehicle(
	@VehicleId int output,
	@ExteriorColorId int,
	@InteriorColorId int,
	@ModelId int,
	@Price decimal(8,2),
	@Year int,
	@DateAdded date,
	@Transmission varchar(30),
	@BodyStyle varchar(30),
	@Mileage varchar(30),
	@VIN varchar(17),
	@MSRP decimal(8,2),
	@Description varchar(120),
	@Condition bit,
	@Picture varchar(30)
)
as 
begin
	update Vehicle set
	ExteriorColorId = @ExteriorColorId,
	InteriorColorId = @InteriorColorId,
	ModelId= @ModelId,
	Price = @Price,
	Year = @Year,
	DateAdded=@DateAdded,
	Transmission=@Transmission,
	BodyStyle=@BodyStyle,
	Mileage=@Mileage,
	VIN = @VIN,
	MSRP = @MSRP,
	Description = @Description,
	Condition = @Condition,
	Picture=@Picture

where VehicleId = @VehicleId
end 
go


IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteVehicle')
	DROP PROCEDURE DeleteVehicle
GO
create procedure DeleteVehicle(
	@VehicleId int
)
as
begin
delete from Vehicle 
where VehicleId = @VehicleId;
end
go

if exists(select* from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAME = 'GetByVehicleId')
	drop procedure GetByVehicleId
go
create procedure GetByVehicleId(
	@VehicleId int
)
as 
begin
select Vehicle.*, Model,Make, EColor, IColor, Make.MakeId
from Vehicle
inner join Model on Vehicle.ModelId = Model.ModelId
inner join Make on Model.MakeId = Make.MakeId
inner join ExteriorColor on Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId
inner join InteriorColor on Vehicle.InteriorColorId =  InteriorColor.InteriorColorId

where VehicleId=@VehicleId
end
go


if exists(select*from INFORMATION_SCHEMA.ROUTINEs
	where Routine_Name = 'GetAllVehicles')
	drop procedure GetAllVehicles
go
create procedure GetAllVehicles
as
begin
select Vehicle.*,Model,Make
from Vehicle
inner join Model on Vehicle.ModelId = Model.ModelId
inner join Make on Model.MakeId = Make.MakeId

end 
go


if exists(select* from INFORMATION_SCHEMA.routines
	where ROUTINE_NAME = 'GetAllByMakeModelYear')
	drop procedure GetAllByMakeModelYear
go
create procedure GetAllByMakeModelYear(
	@QuickSearch varchar(30)
)
as
begin
select Vehicle.*,Model,Make, EColor, IColor
from Vehicle
inner join Model on Vehicle.ModelId = Model.ModelId
inner join Make on Model.MakeId = Make.MakeId
inner join ExteriorColor on Vehicle.ExteriorColorId = ExteriorColor.ExteriorColorId
inner join InteriorColor on Vehicle.InteriorColorId =  InteriorColor.InteriorColorId

where
(Model like '%'+@QuickSearch+'%' or 
Make like '%' + @QuickSearch+'%' or
Year Like '%'+@QuickSearch+'%' or
((Make like '%'+@QuickSearch+'%') and (Model like '%'+@QuickSearch+'%')))


end
go



---Sales----
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateSale')
	DROP PROCEDURE CreateSale
GO


create procedure CreateSale(
	@SaleId int output,
	@Name varchar(30),
	@Phone varchar(12),
	@Email varchar(30),
	@Street1 varchar(30),
	@Street2 varchar(30),
	@City varchar(30),
	@Zipcode varchar(5),
	@StateId int,
	@PurchasedPrice decimal(8,2),
	@PurchaseTypeId int,
	@VehicleId int

)
as
begin
	insert into Sale(Name,Phone,Email,Street1, Street2, City,Zipcode,StateId,PurchasedPrice,PurchaseTypeId,VehicleId)
	values(@Name,@Phone,@Email,@Street1, @Street2, @City,@Zipcode,@StateId,@PurchasedPrice,@PurchaseTypeId,@VehicleId)
	set @SaleId = @@IDENTITY;
end
go




if exists(select*from information_schema.routines
	where routine_name = 'GetSaleById')
	drop procedure GetSaleById
go

create procedure GetSaleById(
	@SaleId int
)
as 
begin
select Sale.*, StateAbbrevation,Type
from Sale
inner join States on Sale.StateId= States.StateId
inner join PurchaseType on Sale.PurchaseTypeId = PurchaseType.PurchaseTypeId
where SaleId=@SaleId
end
go



if exists(select*from INFORMATION_SCHEMA.ROUTINEs
	where Routine_Name = 'GetAllSales')
	drop procedure GetAllSales
go
create procedure GetAllSales
as
begin
select Sale.*,StateAbbrevation,Type
from Sale
inner join States on Sale.StateId= States.StateId
inner join PurchaseType on Sale.PurchaseTypeId = PurchaseType.PurchaseTypeId

end 
go

if exists(select*from information_schema.routines
	where routine_name ='GetAllUsers')
	drop procedure GetAllUsers
go
create procedure GetAllUsers
as 
begin
select distinct Name
from Sale
group by Name
end 
go

if exists(select*from information_schema.routines
	where routine_name ='GetTotalSalesCount')
	drop procedure GetTotalSalesCount
go
create procedure GetTotalSalesCount(
	@SaleDateMin date,
	@SaleDateMax date,
	@Name varchar(30)
)
as
begin
select Distinct Name, Sum(PurchasedPrice) as Sum,count(Name) as Count
from Sale

where (SaleDate >= @SaleDateMin and SaleDate <= @SaleDateMax) or (Name like @Name) or ((SaleDate >= @SaleDateMin and SaleDate <= @SaleDateMax)and(Name like @Name))
group by Name
end
go



---States---
if exists(select*from INFORMATION_SCHEMA.ROUTINEs
	where Routine_Name = 'GetAllStates')
	drop procedure GetAllStates
go
create procedure GetAllStates
as
begin
select *
from States


end 
go



---Puchase Types---

if exists(select*from INFORMATION_SCHEMA.ROUTINEs
	where Routine_Name = 'GetAllPurchaseTypes')
	drop procedure GetAllPurchaseTypes
go
create procedure GetAllPurchaseTypes
as
begin
select *
from PurchaseType


end 
go


if exists(select*from information_schema.routines
	where routine_name = 'GetStateById')
	drop procedure GetStateById
go

create procedure GetStateById(
	@StateId int
)
as 
begin
select *
from States
where StateId=@StateId
end
go