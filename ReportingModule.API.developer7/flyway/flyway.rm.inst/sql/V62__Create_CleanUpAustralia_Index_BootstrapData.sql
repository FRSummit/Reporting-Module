CREATE TABLE [dbo].[CleanUpAustraliaSocialWelfareData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_CleanUpAustraliaSocialWelfareData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[CleanUpAustraliaSocialWelfareGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_CleanUpAustraliaSocialWelfareGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE dbo.CleanUpAustraliaSocialWelfareData ADD CONSTRAINT FK_CleanUpAustraliaSocialWelfareData FOREIGN KEY (ReportId)
REFERENCES Report (Id)
GO

ALTER TABLE dbo.CleanUpAustraliaSocialWelfareGeneratedData ADD CONSTRAINT FK_CleanUpAustraliaSocialWelfareGeneratedData FOREIGN KEY (ReportId)
REFERENCES Report (Id)
GO

; With X As
    (
        Select Id
        From Report 
		WHERE Id NOT IN (SELECT [ReportId] from [dbo].[CleanUpAustraliaSocialWelfareData])
    )

INSERT INTO [dbo].[CleanUpAustraliaSocialWelfareData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 0 , NULL , 0 , NULL from X 

; With X As
    (
        Select Id
        From Report 
		WHERE Id NOT IN (SELECT [ReportId] from [dbo].[CleanUpAustraliaSocialWelfareGeneratedData])
		
    )
INSERT INTO [dbo].[CleanUpAustraliaSocialWelfareGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 0 , NULL , 0 , NULL from X 