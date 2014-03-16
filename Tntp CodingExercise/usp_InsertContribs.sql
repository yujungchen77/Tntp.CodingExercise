USE [bios]
GO
/****** Object:  StoredProcedure [dbo].[usp_InsertContribs]    Script Date: 03/15/2014 14:08:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[usp_InsertContribs]
	@_id nvarchar(50),
	@birth datetime,
	@firstname nvarchar(50),
	@lastname nvarchar(50),
	@contrib nvarchar(100)
	
AS
BEGIN
	
	INSERT INTO  Contribs  (_id, birth, firstname, lastname, contrib)
     VALUES (@_id, @birth, @firstname, @lastname, @contrib)
	
	
END
