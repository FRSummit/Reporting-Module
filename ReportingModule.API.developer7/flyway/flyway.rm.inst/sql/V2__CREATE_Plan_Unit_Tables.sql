
CREATE TABLE [dbo].[Identifier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[IdentifierType] [int] NOT NULL,
	[CurrentIndex] [int] NOT NULL,
 CONSTRAINT [pk_Identifier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ReportEventLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationId] [int] NULL,
	[ReportId] [int] NULL,
	[MessageType] [nvarchar](255) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[CreatedByUsername] [nvarchar](255) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[Visibility] [int] NOT NULL,
	
 CONSTRAINT [pk_ReportEventLog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Organization](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[OrganizationType] [int] NOT NULL,
	[ReportingFrequency] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[ParentDescription] [nvarchar](255) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[OrganizationUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Role] [nvarchar](255) NOT NULL,	
	[OrganizationId] [int] NOT NULL,
	[OrganizationDescription] [nvarchar](255) NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_OrganizationUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Report](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](255) NOT NULL,
	[OrganizationId] [int] NOT NULL,
	[OrganizationDescription] [nvarchar](255) NOT NULL,
	[OrganizationOrganizationType] [int] NOT NULL,
	[OrganizationReportingFrequency] [int] NOT NULL,
	[ReportingPeriodYear] [int] NOT NULL,
	[ReportingPeriodReportingFrequency] [int] NOT NULL,
	[ReportingPeriodReportingTerm] [int] NOT NULL,
	[ReportingPeriodStartDate] [datetime] NOT NULL,
	[ReportingPeriodEndDate] [datetime] NOT NULL,
	[ReportStatus] [int] NOT NULL,
	[ReopenedReportStatus] [int] NOT NULL,
	[Timestamp] [datetime] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AssociateMemberData](
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
 CONSTRAINT [PK_AssociateMemberData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AssociateMemberGeneratedData](
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
 CONSTRAINT [PK_AssociateMemberGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[PreliminaryMemberData](
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
 CONSTRAINT [PK_PreliminaryMemberData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[PreliminaryMemberGeneratedData](
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
 CONSTRAINT [PK_PreliminaryMemberGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[WorkerMeetingData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_WorkerMeetingData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[WorkerMeetingGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_WorkerMeetingGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO