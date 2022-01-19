USE [TextDb]
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE InsertPerson 
	@FirstName varchar(30),
	@LastName varchar(30),
	@Salary int
AS
BEGIN
	INSERT INTO Person(FirstName, LastName, Salary)
    VALUES (@FirstName, @LastName,@Salary)
	
END
GO
