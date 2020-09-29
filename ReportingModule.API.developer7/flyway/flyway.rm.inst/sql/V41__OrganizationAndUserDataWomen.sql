--Organization
declare @wmn int, @wmnUnit int;

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('WMN' ,3 ,3 ,1 ,'Central' ,GETDATE() ,0)
SET @wmn = @@IDENTITY
--Unit
INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('WMN Unit' ,1 ,1 ,@wmn ,'WMN' ,GETDATE() ,0)
SET @wmnUnit = @@IDENTITY

GO