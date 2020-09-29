CREATE TABLE [dbo].[BookLibraryStockData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[LastPeriod] [int] NOT NULL,
	[Increased] [int] NOT NULL,
	[Decreased] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_BookLibraryStockData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[BookLibraryStockGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[LastPeriod] [int] NOT NULL,
	[Increased] [int] NOT NULL,
	[Decreased] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_BookLibraryStockGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[VhsLibraryStockData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[LastPeriod] [int] NOT NULL,
	[Increased] [int] NOT NULL,
	[Decreased] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_VhsLibraryStockData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[VhsLibraryStockGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[LastPeriod] [int] NOT NULL,
	[Increased] [int] NOT NULL,
	[Decreased] [int] NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_VhsLibraryStockGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO