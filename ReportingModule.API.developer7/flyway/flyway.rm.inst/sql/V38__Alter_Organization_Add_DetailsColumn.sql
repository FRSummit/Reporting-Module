ALTER TABLE [dbo].[Organization]
ADD  [Details] [nvarchar] (500) NULL
GO

ALTER TABLE [dbo].[Report]
ADD  [OrganizationDetails] [nvarchar] (500) NULL
GO
	