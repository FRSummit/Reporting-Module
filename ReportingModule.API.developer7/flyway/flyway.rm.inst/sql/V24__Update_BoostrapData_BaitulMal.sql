; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[BaitulMalFinanceData]
           ([ReportId]
           ,[Action]
           ,[WorkerPromiseIncreasedCurrency]
           ,[WorkerPromiseIncreasedAmount]
           ,[WorkerPromiseDecreasedCurrency]
           ,[WorkerPromiseDecreasedAmount]
           ,[WorkerPromiseIncreaseTargetCurrency]
           ,[WorkerPromiseIncreaseTargetAmount]
           ,[WorkerPromiseLastPeriodCurrency]
           ,[WorkerPromiseLastPeriodAmount]
           ,[CollectionCurrency]
           ,[CollectionAmount]
           ,[ExpenseCurrency]
           ,[ExpenseAmount]
           ,[NisabPaidToCentralCurrency]
           ,[NisabPaidToCentralAmount]
           ,[Comment]
           ,[OtherSourceIncreaseTargetCurrency]
           ,[OtherSourceIncreaseTargetAmount]
           ,[OtherSourceAction])

select X.Id, NULL, 8 , 0, 8 , 0,8 , 0,8 , 0,8 , 0,8 , 0,8 , 0,NULL, 8 , 0,NULL from X 
GO
; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[BaitulMalFinanceGeneratedData]
           ([ReportId]
           ,[Action]
           ,[WorkerPromiseIncreasedCurrency]
           ,[WorkerPromiseIncreasedAmount]
           ,[WorkerPromiseDecreasedCurrency]
           ,[WorkerPromiseDecreasedAmount]
           ,[WorkerPromiseIncreaseTargetCurrency]
           ,[WorkerPromiseIncreaseTargetAmount]
           ,[WorkerPromiseLastPeriodCurrency]
           ,[WorkerPromiseLastPeriodAmount]
           ,[CollectionCurrency]
           ,[CollectionAmount]
           ,[ExpenseCurrency]
           ,[ExpenseAmount]
           ,[NisabPaidToCentralCurrency]
           ,[NisabPaidToCentralAmount]
           ,[Comment]
           ,[OtherSourceIncreaseTargetCurrency]
           ,[OtherSourceIncreaseTargetAmount]
           ,[OtherSourceAction])

select X.Id, NULL, 8 , 0, 8 , 0,8 , 0,8 , 0,8 , 0,8 , 0,8 , 0,NULL, 8 , 0,NULL from X 
GO