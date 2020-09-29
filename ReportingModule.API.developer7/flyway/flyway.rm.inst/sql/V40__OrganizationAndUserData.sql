--Organization
declare @central int, @victoria int, @footscrayUnit int, @truganinaNorthUnit int, @sunshineUnit int;
declare @nsw int, @nswzoneone int, @lakembaUnit int;
declare @act int, @actoneone int, @canberraUnit int;
declare @qld int, @qldzoneone int, @brisbaneUnit int;
declare @sa int, @sazoneone int, @adelaideUnit int;
declare @wa int, @wazoneone int, @perthUnit int;
declare @nt int, @ntzoneone int, @darwinUnit int;
declare @tas int, @taszoneone int, @hobartUnit int;


INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Central' ,5 ,12 ,0 ,'Root' ,GETDATE() ,0)
SET @central = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('ACT' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @act = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Victoria' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @victoria = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('NSW' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @nsw = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('QLD' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @qld = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('SA' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @sa = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('WA' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @wa = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('NT' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @nt = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('TAS' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @tas = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Footscray Unit' ,1 ,1 ,@victoria ,'Victoria' ,GETDATE() ,0)
SET @footscrayUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Sunshine Unit' ,1 ,1 ,@victoria ,'Victoria' ,GETDATE() ,0)
SET @sunshineUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Truganina North Unit' ,1 ,1 ,@victoria ,'Victoria' ,GETDATE() ,0)
SET @truganinaNorthUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Canberra Unit' ,1 ,1 ,@act ,'ACT' ,GETDATE() ,0)
SET @canberraUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Brisbane Unit' ,1 ,1 ,@qld ,'QLD' ,GETDATE() ,0)
SET @brisbaneUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('adelaide Unit' ,1 ,1 ,@sa ,'South Australia' ,GETDATE() ,0)
SET @adelaideUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Perth Unit' ,1 ,1 ,@wa ,'Western Australia' ,GETDATE() ,0)
SET @perthUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Darwin Unit' ,1 ,1 ,@nt ,'Northern Australia' ,GETDATE() ,0)
SET @darwinUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Hobart Unit' ,1 ,1 ,@tas ,'Tasmania' ,GETDATE() ,0)
SET @hobartUnit = @@IDENTITY

--OrganizationUser
INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('shahed.khan@simplexhub.com' ,'Admin', @victoria ,'Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('central@test.com' ,'Admin', @central ,'Central' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('victoria@test.com' ,'Admin', @victoria ,'Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('sunshineunit@test.com' ,'Admin', @sunshineUnit ,'Sunshine Unit' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('footscrayunit@test.com' ,'Admin', @footscrayUnit ,'Footscray Unit' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('truganinaNorthUnit@test.com' ,'Admin', @truganinaNorthUnit ,'Truganina North Unit' ,GETDATE() ,0)

--PM--
INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('mmmonir@yahoo.com' ,'Admin', @victoria ,'Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('monir.kl@yahoo.com' ,'Admin', @truganinaNorthUnit ,'Truganina North Unit' ,GETDATE() ,0)

GO
