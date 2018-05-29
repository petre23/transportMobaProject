CREATE TABLE [dbo].[Users]
(
	[Id] Uniqueidentifier NOT NULL,
	[Username] nvarchar(255) NOT NULL,
	[Password] nvarchar(255) NOT NULL,
	[FirstName] nvarchar(255) NOT NULL,
	[SurName] nvarchar(255) NOT NULL,
	[HasAdminRole] bit NOT NULL DEFAULT 1,
	PRIMARY KEY(Id)
)
