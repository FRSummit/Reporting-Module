; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[BookLibraryStockData] ([ReportId],[LastPeriod] ,[Increased] ,[Decreased]  ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[BookLibraryStockGeneratedData] ([ReportId] ,[LastPeriod] ,[Increased] ,[Decreased]  ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[VhsLibraryStockData] ([ReportId] ,[LastPeriod] ,[Increased] ,[Decreased]  ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[VhsLibraryStockGeneratedData] ([ReportId] ,[LastPeriod] ,[Increased] ,[Decreased]  ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

