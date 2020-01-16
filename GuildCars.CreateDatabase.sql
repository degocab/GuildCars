USE master
GO

--dropping database if it exists
IF EXISTS(select * from sys.databases where name='GuildCars')
DROP DATABASE GuildCars
GO
--creating the database
CREATE DATABASE GuildCars
GO