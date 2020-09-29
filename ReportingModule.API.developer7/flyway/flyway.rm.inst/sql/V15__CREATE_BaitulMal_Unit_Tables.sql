CREATE TABLE [dbo].[BaitulMalFinanceData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Action] [nvarchar](255) NULL,
	[WorkerPromiseIncreasedCurrency] [int] NOT NULL,
	[WorkerPromiseIncreasedAmount] [decimal](18,3) NOT NULL,	
	[WorkerPromiseDecreasedCurrency] [int] NOT NULL,	
	[WorkerPromiseDecreasedAmount] [decimal](18,3) NOT NULL,	
	[WorkerPromiseIncreaseTargetCurrency] [int] NOT NULL,
	[WorkerPromiseIncreaseTargetAmount] [decimal](18,3) NOT NULL,
	[WorkerPromiseLastPeriodCurrency] [int] NOT NULL,
	[WorkerPromiseLastPeriodAmount] [decimal](18,3) NOT NULL,
	[CollectionCurrency] [int] NOT NULL,
	[CollectionAmount] [decimal](18,3) NOT NULL,
	[ExpenseCurrency] [int] NOT NULL,
	[ExpenseAmount] [decimal](18,3) NOT NULL,
	[NisabPaidToCentralCurrency] [int] NOT NULL,
	[NisabPaidToCentralAmount] [decimal](18,3) NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_BaitulMalFinanceData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[BaitulMalFinanceGeneratedData](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReportId] [int] NOT NULL,
	[Action] [nvarchar](255) NULL,
	[WorkerPromiseIncreasedCurrency] [int] NOT NULL,
	[WorkerPromiseIncreasedAmount] [decimal](18,3) NOT NULL,	
	[WorkerPromiseDecreasedCurrency] [int] NOT NULL,	
	[WorkerPromiseDecreasedAmount] [decimal](18,3) NOT NULL,	
	[WorkerPromiseIncreaseTargetCurrency] [int] NOT NULL,
	[WorkerPromiseIncreaseTargetAmount] [decimal](18,3) NOT NULL,
	[WorkerPromiseLastPeriodCurrency] [int] NOT NULL,
	[WorkerPromiseLastPeriodAmount] [decimal](18,3) NOT NULL,
	[CollectionCurrency] [int] NOT NULL,
	[CollectionAmount] [decimal](18,3) NOT NULL,
	[ExpenseCurrency] [int] NOT NULL,
	[ExpenseAmount] [decimal](18,3) NOT NULL,
	[NisabPaidToCentralCurrency] [int] NOT NULL,
	[NisabPaidToCentralAmount] [decimal](18,3) NOT NULL,
	[Comment] [nvarchar](255) NULL,
 CONSTRAINT [PK_BaitulMalFinanceGeneratedData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO