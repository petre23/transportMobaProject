﻿CREATE TABLE [dbo].[DriveStatus]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Status] NVARCHAR(255) NOT NULL,
	[Order] int NULL,
)
