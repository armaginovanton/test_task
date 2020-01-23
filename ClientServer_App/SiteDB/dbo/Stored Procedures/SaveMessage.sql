CREATE PROCEDURE [dbo].[SaveMessage]  
	@text	NVARCHAR (225) = NULL,
	@ip     NVARCHAR (50) = NULL,
	@getDateTime DATETIME = NULL
AS
BEGIN
INSERT [dbo].[Message]([TEXT],[IP],[getDateTime])
OUTPUT inserted.*
VALUES(@text,@ip,@getDateTime)


END;