USE [Calculations]
GO
/****** Object:  StoredProcedure [dbo].[InsertCalculatorResult]    Script Date: 04/10/2018 19:52:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertCalculatorResult]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertCalculatorResult]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertCalculatorResult]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- =============================================
-- Author:		Ram
-- Create date: 20Jan2014
-- Description:	Inserts a calculator function result  
--				
-- =============================================

CREATE PROCEDURE [dbo].[InsertCalculatorResult]
(
			 @FunctionName varchar(50)
			,@FunctionResult varchar(50)
)			
AS
BEGIN
    
	SET NOCOUNT ON;
	--inserting record
	INSERT INTO [dbo].[CalculatorResult]
           ([FunctionName]
           ,[FunctionResult])
     VALUES
           (ISNULL(@FunctionName, '''')
           ,ISNULL(@FunctionResult, '''')
          )
	
	RETURN
END'
END
GO
GRANT EXECUTE ON [dbo].[InsertCalculatorResult] TO [RamsFamily\Ramnath] AS [dbo]
GO

