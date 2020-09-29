CREATE TABLE [dbo].[SupporterMemberData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[NameAndContactNumber] [nvarchar](255) NULL,
	[LastPeriod] [int] NOT NULL,
	[Action] [nvarchar](255) NULL,
	[UpgradeTarget] [int] NOT NULL,
	[Increased] [int] NOT NULL,
	[Decreased] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
	[PersonalContact] [nvarchar](255) NULL,	
 CONSTRAINT [PK_SupporterMemberData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[SupporterMemberGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[NameAndContactNumber] [nvarchar](255) NULL,
	[LastPeriod] [int] NOT NULL,
	[Action] [nvarchar](255) NULL,
	[UpgradeTarget] [int] NOT NULL,
	[Increased] [int] NOT NULL,
	[Decreased] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
	[PersonalContact] [nvarchar](255) NULL,	
 CONSTRAINT [PK_SupporterMemberGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO