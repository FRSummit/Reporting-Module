
ALTER TABLE [dbo].[BaitulMalFinanceData]
ADD  [LastPeriodCurrency] [int]
GO
ALTER TABLE [dbo].[BaitulMalFinanceData]
ADD [LastPeriodAmount] [decimal](18,3)
GO


UPDATE BaitulMalFinanceData 
SET LastPeriodCurrency = 8, LastPeriodAmount = 0
WHERE LastPeriodCurrency IS NULL AND LastPeriodAmount IS NULL
GO


ALTER TABLE [dbo].[BaitulMalFinanceData]
ALTER COLUMN  [LastPeriodCurrency] [int] NOT NULL
GO
ALTER TABLE [dbo].[BaitulMalFinanceData]
ALTER COLUMN [LastPeriodAmount] [decimal](18,3) NOT NULL
GO


ALTER TABLE [dbo].[BaitulMalFinanceGeneratedData]
ADD  [LastPeriodCurrency] [int]
GO
ALTER TABLE [dbo].[BaitulMalFinanceGeneratedData]
ADD [LastPeriodAmount] [decimal](18,3)
GO


UPDATE BaitulMalFinanceGeneratedData 
SET LastPeriodCurrency = 8, LastPeriodAmount = 0
WHERE LastPeriodCurrency IS NULL AND LastPeriodAmount IS NULL
GO


ALTER TABLE [dbo].[BaitulMalFinanceGeneratedData]
ALTER COLUMN  [LastPeriodCurrency] [int] NOT NULL
GO
ALTER TABLE [dbo].[BaitulMalFinanceGeneratedData]
ALTER COLUMN [LastPeriodAmount] [decimal](18,3) NOT NULL
GO


ALTER TABLE [dbo].[ADayMasjidProjectFinanceData]
ADD  [LastPeriodCurrency] [int]
GO
ALTER TABLE [dbo].[ADayMasjidProjectFinanceData]
ADD [LastPeriodAmount] [decimal](18,3)
GO


UPDATE ADayMasjidProjectFinanceData 
SET LastPeriodCurrency = 8, LastPeriodAmount = 0
WHERE LastPeriodCurrency IS NULL AND LastPeriodAmount IS NULL
GO


ALTER TABLE [dbo].[ADayMasjidProjectFinanceData]
ALTER COLUMN  [LastPeriodCurrency] [int] NOT NULL
GO
ALTER TABLE [dbo].[ADayMasjidProjectFinanceData]
ALTER COLUMN [LastPeriodAmount] [decimal](18,3) NOT NULL
GO


ALTER TABLE [dbo].[ADayMasjidProjectFinanceGeneratedData]
ADD  [LastPeriodCurrency] [int]
GO
ALTER TABLE [dbo].[ADayMasjidProjectFinanceGeneratedData]
ADD [LastPeriodAmount] [decimal](18,3)
GO


UPDATE ADayMasjidProjectFinanceGeneratedData 
SET LastPeriodCurrency = 8, LastPeriodAmount = 0
WHERE LastPeriodCurrency IS NULL AND LastPeriodAmount IS NULL
GO


ALTER TABLE [dbo].[ADayMasjidProjectFinanceGeneratedData]
ALTER COLUMN  [LastPeriodCurrency] [int] NOT NULL
GO
ALTER TABLE [dbo].[ADayMasjidProjectFinanceGeneratedData]
ALTER COLUMN [LastPeriodAmount] [decimal](18,3) NOT NULL
GO


ALTER TABLE [dbo].[MasjidTableBankFinanceData]
ADD  [LastPeriodCurrency] [int]
GO
ALTER TABLE [dbo].[MasjidTableBankFinanceData]
ADD [LastPeriodAmount] [decimal](18,3)
GO


UPDATE MasjidTableBankFinanceData 
SET LastPeriodCurrency = 8, LastPeriodAmount = 0
WHERE LastPeriodCurrency IS NULL AND LastPeriodAmount IS NULL
GO


ALTER TABLE [dbo].[MasjidTableBankFinanceData]
ALTER COLUMN  [LastPeriodCurrency] [int] NOT NULL
GO
ALTER TABLE [dbo].[MasjidTableBankFinanceData]
ALTER COLUMN [LastPeriodAmount] [decimal](18,3) NOT NULL
GO


ALTER TABLE [dbo].[MasjidTableBankFinanceGeneratedData]
ADD  [LastPeriodCurrency] [int]
GO
ALTER TABLE [dbo].[MasjidTableBankFinanceGeneratedData]
ADD [LastPeriodAmount] [decimal](18,3)
GO


UPDATE MasjidTableBankFinanceGeneratedData 
SET LastPeriodCurrency = 8, LastPeriodAmount = 0
WHERE LastPeriodCurrency IS NULL AND LastPeriodAmount IS NULL
GO


ALTER TABLE [dbo].[MasjidTableBankFinanceGeneratedData]
ALTER COLUMN  [LastPeriodCurrency] [int] NOT NULL
GO


ALTER TABLE [dbo].[MasjidTableBankFinanceGeneratedData]
ALTER COLUMN [LastPeriodAmount] [decimal](18,3) NOT NULL
GO