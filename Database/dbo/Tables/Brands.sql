﻿CREATE TABLE [dbo].[Brands]
(
	[Id] UNIQUEIDENTIFIER NOT NULL, 
    [Name] NVARCHAR(255) NOT NULL,
	[Value] int NOT NULL,
	PRIMARY KEY(Id)
)
