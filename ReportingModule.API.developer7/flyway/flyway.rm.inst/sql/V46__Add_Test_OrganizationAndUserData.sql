--Organization
declare @testCentral int, @testVictoria int, @testNSWZone int, @testTruganinaNorthUnit int, @testCanberraUnit int, @testPerthUnit int, @testAdelaideUnit int;

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Test Central' ,5 ,12 ,0 ,'Root' ,GETDATE() ,0)
SET @testCentral = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Test Victoria' ,3 ,3 ,@testCentral ,'Test Central' ,GETDATE() ,0)
SET @testVictoria = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Test NSW Zone' ,2 ,1 ,@testVictoria ,'Test Victoria' ,GETDATE() ,0)
SET @testNSWZone = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Test truganinaNorth Unit' ,1 ,1 ,@testNSWZone ,'Test NSW Zone' ,GETDATE() ,0)
SET @testTruganinaNorthUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Test Canberra Unit' ,1 ,1 ,@testNSWZone ,'Test NSW Zone' ,GETDATE() ,0)
SET @testCanberraUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Test Perth Unit' ,1 ,1 ,@testVictoria ,'Test Victoria' ,GETDATE() ,0)
SET @testPerthUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Test Adelaide Unit' ,1 ,1 ,@testVictoria ,'Test Victoria' ,GETDATE() ,0)
SET @testAdelaideUnit = @@IDENTITY


--OrganizationUser

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('shahed.khan@simplexhub.com' ,'Admin', @testVictoria ,'Test Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('central@test.com' ,'Admin', @testCentral ,'Test Central' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('victoria@test.com' ,'Admin', @testVictoria ,'Test Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('truganinaNorthUnit@test.com' ,'Admin', @testTruganinaNorthUnit ,'Test truganinaNorth Unit' ,GETDATE() ,0)

--PM--
INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('mmmonir@yahoo.com' ,'Admin', @testVictoria ,'Test Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('monir.kl@yahoo.com' ,'Admin', @testTruganinaNorthUnit ,'Test truganinaNorth Unit' ,GETDATE() ,0)

GO