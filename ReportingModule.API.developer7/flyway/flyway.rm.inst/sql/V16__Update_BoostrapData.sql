; With X As
    (
        Select Description 
        From Organization 
		Where OrganizationType = 1
    )

Update X set Description = Description + ', President: Mohammad Mostadir, State: Victoria.'


; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[MemberMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
select X.Id,'' ,1 ,'' ,1 ,0 ,0 ,'' ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[MemberMemberGeneratedData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
select X.Id,'' ,1 ,'' ,1 ,0 ,0 ,'' ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )

INSERT INTO [dbo].[SupporterMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
select X.Id,'' ,1 ,'' ,1 ,0 ,0 ,'' ,'' from X 

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[SupporterMemberGeneratedData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
select X.Id,'' ,1 ,'' ,1 ,0 ,0 ,'' ,'' from X 


; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[DawahGroupMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[DawahGroupMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[DawahMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[DawahMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[IftarMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[IftarMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[LearningMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[LearningMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[NextGMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[NextGMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[SocialDawahMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[SocialDawahMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[StateLeaderMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[StateLEaderMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[StateOutingMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X

; With X As
    (
        Select Id
        From Report 
		
    )
INSERT INTO [dbo].[StateOutingMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
select X.Id ,1 ,'' ,1 ,6 ,'' from X


