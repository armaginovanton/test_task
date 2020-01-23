CREATE PROCEDURE [dbo].[GetMessage]
	@ID int
AS 
SELECT  
	[ID],
	[TEXT],
	[IP],
	[getDateTime]
FROM [dbo].[Message]
WHERE [ID] = @ID