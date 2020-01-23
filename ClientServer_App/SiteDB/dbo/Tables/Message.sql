CREATE TABLE [dbo].[Message] (
    [ID]			INT            IDENTITY (1, 1) NOT NULL,
    [TEXT]			NVARCHAR (255) NOT NULL,
    [IP]			NVARCHAR (50)  NOT NULL,
    [getDateTime]   DATETIME       NOT NULL
	PRIMARY KEY CLUSTERED ([ID] ASC)
);