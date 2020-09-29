
INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('Truganina South Unit' ,1 ,1 ,3 ,'Victoria' ,GETDATE() ,0 ,'President: Capt. Faruk Ahmed')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('Tarneit Unit' ,1 ,1 ,3 ,'Victoria' ,GETDATE() ,0 ,'President: Omar Faruq')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('Williams Landing Unit' ,1 ,1 ,3,'Victoria' ,GETDATE() ,0 ,'President: Al-Amin Jnr')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('Point Cook Unit' ,1 ,1 ,3,'Victoria' ,GETDATE() ,0 ,'President: Hafizur Rahman')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('Clayton Unit' ,1 ,1 ,3 ,'Victoria' ,GETDATE() ,0 ,'President: Abdur Rahim Snr')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('Fawkner Unit' ,1 ,1 ,3 ,'Victoria' ,GETDATE() ,0 ,'President: Rezwan Farid Ahmed')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('YMB (SNR) Unit' ,1 ,1 ,3 ,'Victoria' ,GETDATE() ,0 ,'President: Saad Pramanik')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('YMB (JNR) Unit' ,1 ,1 ,3 ,'Victoria' ,GETDATE() ,0 ,'President: Yusuf Amin')

GO

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted] ,[Details]) 
VALUES ('Street Dawah Unit' ,1 ,1 ,3 ,'Victoria' ,GETDATE() ,0 ,'In Charge: Afzalul Kabir')

GO

UPDATE [dbo].[Organization]
SET [Details] = 'President: Khurshed Alam'
WHERE [Id] = 3

UPDATE [dbo].[Organization]
SET [Details] = 'President: Shamsul Alom'
WHERE [Description] LIKE '%Truganina North Unit%'

UPDATE [dbo].[Organization]
SET [Details] = 'President: Dr Eng Rafiqul Islam'
WHERE [Description] LIKE '%Footscray Unit%'

UPDATE [dbo].[Organization]
SET [Details] = 'President: Sakinul Islam'
WHERE [Description] LIKE '%Sunshine Unit%'

GO