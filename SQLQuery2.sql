USE [SamuraiDB]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[SamuraisWhoSaidAWord]
		@text = NULL

SELECT	@return_value as 'Return Value'

GO
