
--Organization
declare @central int, @victoria int, @footscrayUnit int, @truganinaNorthUnit int, @sunshineUnit int;
declare @nsw int, @nswzoneone int, @lakembaUnit int

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Central' ,5 ,12 ,0 ,'Root' ,GETDATE() ,0)
SET @central = @@IDENTITY



INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Victoria' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @victoria = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Footscray Unit' ,1 ,1 ,@victoria ,'Victoria' ,GETDATE() ,0)
SET @footscrayUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Sunshine Unit' ,1 ,1 ,@victoria ,'Victoria' ,GETDATE() ,0)
SET @sunshineUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Truganina North Unit' ,1 ,1 ,@victoria ,'Victoria' ,GETDATE() ,0)
SET @truganinaNorthUnit = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('NSW' ,3 ,3 ,@central ,'Central' ,GETDATE() ,0)
SET @nsw = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('NSW Zone One' ,2 ,1 ,@nsw ,'NSW' ,GETDATE() ,0)
SET @nswzoneone = @@IDENTITY

INSERT INTO [dbo].[Organization] ([Description] ,[OrganizationType] ,[ReportingFrequency] ,[ParentId] ,[ParentDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('Lakemba Unit' ,1 ,1 ,@nswzoneone ,'NSW Zone One' ,GETDATE() ,0)
SET @lakembaUnit = @@IDENTITY


--OrganizationUser
INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('shahed.khan@simplexhub.com' ,'Admin', @victoria ,'Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('central@test.com' ,'Admin', @central ,'Central' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('victoria@test.com' ,'Admin', @victoria ,'Victoria' ,GETDATE() ,0)


INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('sunshineunit@test.com' ,'Admin', @sunshineUnit ,'Sunshine Unit' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('footscrayunit@test.com' ,'Admin', @footscrayUnit ,'Footscray Unit' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('truganinaNorthUnit@test.com' ,'Admin', @truganinaNorthUnit ,'Truganina North Unit' ,GETDATE() ,0)


--PM--
INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('mmmonir@yahoo.com' ,'Admin', @victoria ,'Victoria' ,GETDATE() ,0)

INSERT INTO [dbo].[OrganizationUser] ([Username] ,[Role] ,[OrganizationId] ,[OrganizationDescription] ,[Timestamp] ,[IsDeleted]) 
VALUES ('monir.kl@yahoo.com' ,'Admin', @truganinaNorthUnit ,'Truganina North Unit' ,GETDATE() ,0)

--Truganina Unit
declare @truganinaUnitJan2019 int, @truganinaUnitFeb2019 int, @truganinaUnitMar2019 int, @truganinaUnitApr2019 int, @truganinaUnitMay2019 int

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-TGN-JAN19' ,@truganinaNorthUnit ,'Truganina North Unit',1 ,1 ,2019 ,1 ,1 ,'2019-01-01 00:00:00.000' ,'2019-01-31 23:59:59.000' ,3 ,0 ,GETDATE() ,0)
SET @truganinaUnitJan2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-TGN-FEBN19' ,@truganinaNorthUnit ,'Truganina North Unit',1 ,1 ,2019 ,1 ,2 ,'2019-02-01 00:00:00.000' ,'2019-02-28 23:59:59.000' ,3 ,0 ,GETDATE() ,0)
SET @truganinaUnitFeb2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-TGN-MAR19' ,@truganinaNorthUnit ,'Truganina North Unit',1 ,1 ,2019 ,1 ,3 ,'2019-03-01 00:00:00.000' ,'2019-03-31 23:59:59.000' ,2 ,0 ,GETDATE() ,0)
SET @truganinaUnitMar2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-TGN-APR19' ,@truganinaNorthUnit ,'Truganina North Unit',1 ,1 ,2019 ,1 ,4 ,'2019-04-01 00:00:00.000' ,'2019-04-30 23:59:59.000' ,1 ,0 ,GETDATE() ,0)
SET @truganinaUnitApr2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-TGN-MAY19' ,@truganinaNorthUnit ,'Truganina North Unit',1 ,1 ,2019 ,1 ,5 ,'2019-05-01 00:00:00.000' ,'2019-05-31 23:59:59.000' ,1 ,0 ,GETDATE() ,0)
SET @truganinaUnitMay2019 = @@IDENTITY


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitJan2019 ,'' ,1 ,'' ,1 ,0 ,0 ,'' ,'')
INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitJan2019 ,'' ,2 ,'' ,1 ,0 ,0 ,'' ,'')
INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@truganinaUnitJan2019 ,1 ,'' ,1 ,6 ,'')

INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitFeb2019 ,'' ,1 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitFeb2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@truganinaUnitFeb2019 ,1 ,'' ,1 ,6 ,'')

INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitMar2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitMar2019 ,'' ,3 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@truganinaUnitMar2019 ,1 ,'' ,1 ,6 ,'')

INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitApr2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitApr2019 ,'' ,3 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@truganinaUnitApr2019 ,1 ,'' ,1 ,6 ,'')


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitMay2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@truganinaUnitMay2019 ,'' ,3 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@truganinaUnitMay2019 ,1 ,'' ,1 ,6 ,'')


--Sunshine Unit
declare @sunshineUnitJan2019 int, @sunshineUnitFeb2019 int, @sunshineUnitMar2019 int, @sunshineUnitApr2019 int, @sunshineUnitMay2019 int

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-SUN-JAN19' ,@sunshineUnit ,'Sunshine Unit',1 ,1 ,2019 ,1 ,1 ,'2019-01-01 00:00:00.000' ,'2019-01-31 23:59:59.000' ,3 ,0 ,GETDATE() ,0)
SET @sunshineUnitJan2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-SUN-FEBN19' ,@sunshineUnit ,'Sunshine Unit',1 ,1 ,2019 ,1 ,2 ,'2019-02-01 00:00:00.000' ,'2019-02-28 23:59:59.000' ,3 ,0 ,GETDATE() ,0)
SET @sunshineUnitFeb2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-SUN-MAR19' ,@sunshineUnit ,'Sunshine Unit',1 ,1 ,2019 ,1 ,3 ,'2019-03-01 00:00:00.000' ,'2019-03-31 23:59:59.000' ,2 ,0 ,GETDATE() ,0)
SET @sunshineUnitMar2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-SUN-APR19' ,@sunshineUnit ,'Sunshine Unit',1 ,1 ,2019 ,1 ,4 ,'2019-04-01 00:00:00.000' ,'2019-04-30 23:59:59.000' ,1 ,0 ,GETDATE() ,0)
SET @sunshineUnitApr2019 = @@IDENTITY

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-SUN-MAY19' ,@sunshineUnit ,'Sunshine Unit',1 ,1 ,2019 ,1 ,5 ,'2019-05-01 00:00:00.000' ,'2019-05-31 23:59:59.000' ,1 ,0 ,GETDATE() ,0)
SET @sunshineUnitMay2019 = @@IDENTITY


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitJan2019 ,'' ,1 ,'' ,1 ,0 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitJan2019 ,'' ,2 ,'' ,1 ,0 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@sunshineUnitJan2019 ,1 ,'' ,1 ,6 ,'')


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitFeb2019 ,'' ,1 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitFeb2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@sunshineUnitFeb2019 ,1 ,'' ,1 ,6 ,'')


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitMar2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitMar2019 ,'' ,3 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@sunshineUnitMar2019 ,1 ,'' ,1 ,6 ,'')


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitApr2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitApr2019 ,'' ,3 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@sunshineUnitApr2019 ,1 ,'' ,1 ,6 ,'')


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitMay2019 ,'' ,2 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@sunshineUnitMay2019 ,'' ,3 ,'' ,1 ,1 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@sunshineUnitMay2019 ,1 ,'' ,1 ,6 ,'')


--Vic
declare @vicJanToMarch2019 int, @vicAprToJun2019 int

INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-JAN-MAR19' ,@victoria ,'Victoria',3 ,3 ,2019 ,1 ,1 ,'2019-01-01 00:00:00.000' ,'2019-03-31 23:59:59.000' ,1 ,0 ,GETDATE() ,0)
SET @vicJanToMarch2019 = @@IDENTITY


INSERT INTO [dbo].[Report] ([Description] ,[OrganizationId] ,[OrganizationDescription] ,[OrganizationOrganizationType] ,[OrganizationReportingFrequency] ,[ReportingPeriodYear] ,[ReportingPeriodReportingFrequency] ,[ReportingPeriodReportingTerm] ,[ReportingPeriodStartDate] ,[ReportingPeriodEndDate] ,[ReportStatus] ,[ReopenedReportStatus] ,[Timestamp] ,[IsDeleted]) 
VALUES ('10001-VIC-APR-JUN19' ,@victoria ,'Victoria',3 ,3 ,2019 ,3 ,2 ,'2019-04-01 00:00:00.000' ,'2019-06-30 23:59:59.000' ,1 ,0 ,GETDATE() ,0)
SET @vicAprToJun2019 = @@IDENTITY



INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicJanToMarch2019 ,'' ,2 ,'' ,2 ,0 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicJanToMarch2019 ,'' ,4 ,'' ,2 ,0 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@vicJanToMarch2019 ,2 ,'' ,2 ,12 ,'')


INSERT INTO [dbo].[AssociateMemberGeneratedData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicJanToMarch2019 ,'' ,2 ,'' ,2 ,0 ,0 ,'' ,'')


INSERT INTO [dbo].[PreliminaryMemberGeneratedData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicJanToMarch2019 ,'' ,4 ,'' ,2 ,0 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@vicJanToMarch2019 ,2 ,'' ,2 ,12 ,'')


INSERT INTO [dbo].[AssociateMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicAprToJun2019 ,'' ,2 ,'' ,2 ,2 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicAprToJun2019 ,'' ,4 ,'' ,2 ,2 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@vicAprToJun2019 ,2 ,'' ,2 ,12 ,'')


INSERT INTO [dbo].[AssociateMemberGeneratedData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicAprToJun2019 ,'' ,2 ,'' ,2 ,2 ,0 ,'' ,'')

INSERT INTO [dbo].[PreliminaryMemberGeneratedData] ([ReportId] ,[NameAndContactNumber] ,[LastPeriod] ,[Action] ,[UpgradeTarget] ,[Increased] ,[Decreased] ,[Comment] ,[PersonalContact]) 
VALUES (@vicAprToJun2019 ,'' ,4 ,'' ,2 ,2 ,0 ,'' ,'')

INSERT INTO [dbo].[WorkerMeetingGeneratedData] ([ReportId] ,[Target] ,[DateAndAction] ,[Actual] ,[AverageAttendance] ,[Comment]) 
VALUES (@vicAprToJun2019 ,2 ,'' ,2 ,12 ,'')

GO
