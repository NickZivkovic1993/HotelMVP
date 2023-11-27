CREATE TABLE [dbo].[RoomTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NCHAR(50) NOT NULL, 
    [Description] NCHAR(2000) NOT NULL, 
    [Price] MONEY NOT NULL
)
