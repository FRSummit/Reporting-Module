; With X As
    (
        Select Id
        From Report 
    )

INSERT INTO [dbo].[QardeHasanaSocialWelfareData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
    )
INSERT INTO [dbo].[QardeHasanaSocialWelfareGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
    )

INSERT INTO [dbo].[PatientVisitSocialWelfareData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
    )
INSERT INTO [dbo].[PatientVisitSocialWelfareGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
    )

INSERT INTO [dbo].[SocialVisitSocialWelfareData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 

; With X As
    (
        Select Id
        From Report 
    )
INSERT INTO [dbo].[SocialVisitSocialWelfareGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[Comment]) 
select X.Id, 1 , '' , 1 ,'' from X 