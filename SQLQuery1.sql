USE [SamuraiDB]
GO

DECLARE	@return_value Char(30)

EXEC	@return_value = [dbo].[EarliestBattleFoughtBySamurai]
		@samuraiId = 2

SELECT	@return_value as 'Return Value'

GO
