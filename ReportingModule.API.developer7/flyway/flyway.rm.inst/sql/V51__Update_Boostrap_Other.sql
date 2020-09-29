; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[OtherMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[OtherMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[OtherSocialWelfareData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[OtherSocialWelfareGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[FoodDistributionSocialWelfareData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[FoodDistributionSocialWelfareGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[OtherSaleMaterialData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[OtherSaleMaterialGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[OtherDistributionMaterialData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[OtherDistributionMaterialGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[OtherLibraryStockData] ([ReportId],[LastPeriod] ,[Increased] ,[Decreased]  ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[OtherLibraryStockGeneratedData] ([ReportId] ,[LastPeriod] ,[Increased] ,[Decreased]  ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[OtherTeachingLearningProgramData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual], AverageAttendance ,[Comment]) 
select X.Id, 1 , '' , 1, 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[OtherTeachingLearningProgramGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] , AverageAttendance,[Comment]) 
select X.Id, 1 , '' , 1, 1 ,'' from X 