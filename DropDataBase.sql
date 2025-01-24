USE [master]
GO

ALTER DATABASE [dima-dev] Set SINGLE_USER WITH ROLLBACK IMMEDIATE;
go

drop database [dima-dev];
GO