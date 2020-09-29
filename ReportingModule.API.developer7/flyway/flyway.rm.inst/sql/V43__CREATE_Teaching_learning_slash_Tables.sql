CREATE TABLE [dbo].[StudyCircleForAssociateMemberTeachingLearningProgramData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_StudyCircleForAssociateMemberTeachingLearningProgramData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_StudyCircleForAssociateMemberTeachingLearningProgramGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[HadithTeachingLearningProgramData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_HadithTeachingLearningProgramData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[HadithTeachingLearningProgramGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_HadithTeachingLearningProgramGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[WeekendIslamicSchoolTeachingLearningProgramData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_WeekendIslamicSchoolTeachingLearningProgramData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[WeekendIslamicSchoolTeachingLearningProgramGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_WeekendIslamicSchoolTeachingLearningProgramGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[MemorizingHadithTeachingLearningProgramData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_MemorizingHadithTeachingLearningProgramData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[MemorizingHadithTeachingLearningProgramGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_MemorizingHadithTeachingLearningProgramGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[MemorizingDoaTeachingLearningProgramData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_MemorizingDoaTeachingLearningProgramData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[MemorizingDoaTeachingLearningProgramGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_MemorizingDoaTeachingLearningProgramGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[OtherTeachingLearningProgramData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_OtherTeachingLearningProgramData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[OtherTeachingLearningProgramGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Target] [int] NOT NULL,
	[DateAndAction] [nvarchar](255) NULL,
	[Actual] [int] NOT NULL,
	[AverageAttendance] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_OtherTeachingLearningProgramGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO