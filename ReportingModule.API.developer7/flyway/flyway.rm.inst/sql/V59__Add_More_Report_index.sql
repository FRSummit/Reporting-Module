
CREATE INDEX index_report_Misc1 ON Report (OrganizationId, OrganizationOrganizationType, ReportStatus, ReportingPeriodStartDate, ReportingPeriodEndDate desc, IsDeleted )
GO

CREATE INDEX index_report_Misc2 ON Report (OrganizationId, OrganizationOrganizationType, ReportStatus, IsDeleted )
GO

DROP INDEX index_report_ReportingPeriodStartDate ON Report 
GO
DROP INDEX index_report_ReportingPeriodEndDate ON Report 
GO
DROP INDEX index_report_ReportStatus ON Report
GO

DROP INDEX index_report_OrganizationOrganizationType ON Report
GO

DROP INDEX index_report_isdeleted ON Report
GO
