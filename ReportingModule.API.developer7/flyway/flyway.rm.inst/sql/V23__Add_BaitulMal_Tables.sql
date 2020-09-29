ALTER TABLE [dbo].[BaitulMalFinanceData]
ADD  [OtherSourceIncreaseTargetCurrency] [int] NOT NULL
GO
ALTER TABLE [dbo].[BaitulMalFinanceData]
ADD [OtherSourceIncreaseTargetAmount] [decimal](18,3) NOT NULL
GO
ALTER TABLE [dbo].[BaitulMalFinanceData]
ADD [OtherSourceAction] [nvarchar](255) NULL
GO

ALTER TABLE [dbo].[BaitulMalFinanceGeneratedData]
ADD [OtherSourceIncreaseTargetCurrency] [int] NOT NULL
GO
ALTER TABLE [dbo].[BaitulMalFinanceGeneratedData]
ADD [OtherSourceIncreaseTargetAmount] [decimal](18,3) NOT NULL
GO
ALTER TABLE [dbo].[BaitulMalFinanceGeneratedData]
ADD [OtherSourceAction] [nvarchar](255) NULL
GO
	