CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [FirstName] NVARCHAR(MAX) NOT NULL, 
    [LastName] NVARCHAR(MAX) NOT NULL, 
    [Birthday] DATE NOT NULL, 
    [RecordBook] NVARCHAR(MAX) NOT NULL
)
