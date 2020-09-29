CREATE VIEW UnitReportView AS
SELECT      Report.Id AS ReportId, 
			Report.Description AS ReportDescription, 
			Report.OrganizationId, 
			Report.OrganizationDescription, 
			Report.OrganizationOrganizationType, 
			Report.OrganizationReportingFrequency, 
			Report.ReportingPeriodYear, 
			Report.ReportingPeriodReportingFrequency, 
			Report.ReportingPeriodReportingTerm, 
			Report.ReportingPeriodStartDate, 
			Report.ReportingPeriodEndDate, Report.ReportStatus, 
			Report.ReopenedReportStatus, Report.Timestamp, 
			Organization.ParentId, 
			Organization.ParentDescription,
            AssociateMemberData.NameAndContactNumber AS AssociateMemberNameAndContactNumber,
            AssociateMemberData.LastPeriod AS AssociateMemberLastPeriod,
            AssociateMemberData.Action AS AssociateMemberAction,
            AssociateMemberData.UpgradeTarget AS AssociateMemberUpgradeTarget,
            AssociateMemberData.Increased AS AssociateMemberIncreased,
            AssociateMemberData.Decreased AS AssociateMemberDecreased,
            AssociateMemberData.Comment AS AssociateMemberComment,
            AssociateMemberData.PersonalContact AS AssociateMemberPersonalContact,
            PreliminaryMemberData.NameAndContactNumber AS PreliminaryMemberNameAndContactNumber,
            PreliminaryMemberData.LastPeriod AS PreliminaryMemberLastPeriod,
            PreliminaryMemberData.Action AS PreliminaryMemberAction,
            PreliminaryMemberData.UpgradeTarget AS PreliminaryMemberUpgradeTarget,
            PreliminaryMemberData.Increased AS PreliminaryMemberIncreased,
            PreliminaryMemberData.Decreased AS PreliminaryMemberDecreased,
            PreliminaryMemberData.Comment AS PreliminaryMemberComment,
            PreliminaryMemberData.PersonalContact AS PreliminaryMemberPersonalContact,
            WorkerMeetingData.Target AS WorkerMeetingTarget,
            WorkerMeetingData.DateAndAction AS WorkerMeetingDateAndAction,
            WorkerMeetingData.Actual AS WorkerMeetingActual,
            WorkerMeetingData.AverageAttendance AS WorkerMeetingAverageAttendance,
            WorkerMeetingData.Comment AS WorkerMeetingComment
            
FROM        Report INNER JOIN
			Organization ON Report.OrganizationId = Organization.Id INNER JOIN
			AssociateMemberData ON Report.Id = AssociateMemberData.Id INNER JOIN
			PreliminaryMemberData ON Report.Id = PreliminaryMemberData.Id INNER JOIN
			WorkerMeetingData ON Report.Id = WorkerMeetingData.Id

WHERE 		Report.IsDeleted = 0
			AND Organization.OrganizationType = 1
			 
GO

CREATE VIEW StateReportView AS
SELECT Report.Id AS ReportId,
            Report.Description AS ReportDescription, 
			Report.OrganizationId, 
			Report.OrganizationDescription, 
			Report.OrganizationOrganizationType, 
			Report.OrganizationReportingFrequency, 
			Report.ReportingPeriodYear, 
			Report.ReportingPeriodReportingFrequency, 
			Report.ReportingPeriodReportingTerm, 
			Report.ReportingPeriodStartDate, 
			Report.ReportingPeriodEndDate, Report.ReportStatus, 
			Report.ReopenedReportStatus, Report.Timestamp, 
			Organization.ParentId, 
			Organization.ParentDescription,
            AssociateMemberData.NameAndContactNumber AS AssociateMemberNameAndContactNumber,
            AssociateMemberData.LastPeriod AS AssociateMemberLastPeriod,
            AssociateMemberData.Action AS AssociateMemberAction,
            AssociateMemberData.UpgradeTarget AS AssociateMemberUpgradeTarget,
            AssociateMemberData.Increased AS AssociateMemberIncreased,
            AssociateMemberData.Decreased AS AssociateMemberDecreased,
            AssociateMemberData.Comment AS AssociateMemberComment,
            AssociateMemberData.PersonalContact AS AssociateMemberPersonalContact,
            AssociateMemberGeneratedData.NameAndContactNumber AS AssociateMemberGeneratedNameAndContactNumber,
            AssociateMemberGeneratedData.LastPeriod AS AssociateMemberGeneratedLastPeriod,
            AssociateMemberGeneratedData.Action AS AssociateMemberGeneratedAction,
            AssociateMemberGeneratedData.UpgradeTarget AS AssociateMemberGeneratedUpgradeTarget,
            AssociateMemberGeneratedData.Increased AS AssociateMemberGeneratedIncreased,
            AssociateMemberGeneratedData.Decreased AS AssociateMemberGeneratedDecreased,
            AssociateMemberGeneratedData.Comment AS AssociateMemberGeneratedComment,
            AssociateMemberGeneratedData.PersonalContact AS AssociateMemberGeneratedPersonalContact,
            PreliminaryMemberData.NameAndContactNumber AS PreliminaryMemberNameAndContactNumber,
            PreliminaryMemberData.LastPeriod AS PreliminaryMemberLastPeriod,
            PreliminaryMemberData.Action AS PreliminaryMemberAction,
            PreliminaryMemberData.UpgradeTarget AS PreliminaryMemberUpgradeTarget,
            PreliminaryMemberData.Increased AS PreliminaryMemberIncreased,
            PreliminaryMemberData.Decreased AS PreliminaryMemberDecreased,
            PreliminaryMemberData.Comment AS PreliminaryMemberComment,
            PreliminaryMemberData.PersonalContact AS PreliminaryMemberPersonalContact,
            PreliminaryMemberGeneratedData.NameAndContactNumber AS PreliminaryMemberGeneratedNameAndContactNumber,
            PreliminaryMemberGeneratedData.LastPeriod AS PreliminaryMemberGeneratedLastPeriod,
            PreliminaryMemberGeneratedData.Action AS PreliminaryMemberGeneratedAction,
            PreliminaryMemberGeneratedData.UpgradeTarget AS PreliminaryMemberGeneratedUpgradeTarget,
            PreliminaryMemberGeneratedData.Increased AS PreliminaryMemberGeneratedIncreased,
            PreliminaryMemberGeneratedData.Decreased AS PreliminaryMemberGeneratedDecreased,
            PreliminaryMemberGeneratedData.Comment AS PreliminaryMemberGeneratedComment,
            PreliminaryMemberGeneratedData.PersonalContact AS PreliminaryMemberGeneratedPersonalContact,
            WorkerMeetingData.Target AS WorkerMeetingTarget,
            WorkerMeetingData.DateAndAction AS WorkerMeetingDateAndAction,
            WorkerMeetingData.Actual AS WorkerMeetingActual,
            WorkerMeetingData.AverageAttendance AS WorkerMeetingAverageAttendance,
            WorkerMeetingData.Comment AS WorkerMeetingComment,
            WorkerMeetingGeneratedData.Target AS WorkerMeetingGeneratedTarget,
            WorkerMeetingGeneratedData.DateAndAction AS WorkerMeetingGeneratedDateAndAction,
            WorkerMeetingGeneratedData.Actual AS WorkerMeetingGeneratedActual,
            WorkerMeetingGeneratedData.AverageAttendance AS WorkerMeetingGeneratedAverageAttendance,
            WorkerMeetingGeneratedData.Comment AS WorkerMeetingGeneratedComment
			
FROM        Report INNER JOIN
            Organization ON Report.OrganizationId = Organization.Id INNER JOIN
            AssociateMemberData ON Report.Id = AssociateMemberData.Id INNER JOIN
            AssociateMemberGeneratedData ON Report.Id = AssociateMemberGeneratedData.Id INNER JOIN
            PreliminaryMemberData ON Report.Id = PreliminaryMemberData.Id INNER JOIN
            PreliminaryMemberGeneratedData ON Report.Id = PreliminaryMemberGeneratedData.Id INNER JOIN
            WorkerMeetingData ON Report.Id = WorkerMeetingData.Id INNER JOIN
            WorkerMeetingGeneratedData ON Report.Id = WorkerMeetingGeneratedData.Id
            WHERE Report.IsDeleted = 0
            AND Organization.OrganizationType = 3		
GO