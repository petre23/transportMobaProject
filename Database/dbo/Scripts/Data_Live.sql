update dbo.DriveStatus set [order]= 1 where id = '11992D93-FAF4-4C40-AAF1-F0795A1BFDA1'
update dbo.DriveStatus set [order] = 2 where id = 'E5DBD140-8681-4CFE-A7A3-69D666DF9059'
update dbo.DriveStatus set [order] = 3 where id = 'F115B8BC-5261-4A05-B0FA-75AF2D8DB444'
update dbo.DriveStatus set [order] = 4 where id = '88569B0C-03CF-428C-8D5D-308D0B377BD6'

INSERT INTO dbo.DriveType VALUES(1,'Pick-Up')
INSERT INTO dbo.DriveType VALUES(2,'Incarcare')
INSERT INTO dbo.DriveType VALUES(3,'Dislocare')
INSERT INTO dbo.DriveType VALUES(4,'Ferry/Train')
INSERT INTO dbo.DriveType VALUES(5,'Drop')
INSERT INTO dbo.DriveType VALUES(6,'Descarcare')