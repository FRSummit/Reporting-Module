DROP INDEX index_report_Misc1 ON Report 
GO

CREATE INDEX index_report_Misc1 ON Report (IsDeleted, OrganizationOrganizationType, OrganizationId, ReportStatus, ReportingPeriodEndDate desc,  ReportingPeriodStartDate)
GO

DROP INDEX index_report_Misc2 ON Report 
GO

CREATE INDEX index_report_Misc2 ON Report (IsDeleted, OrganizationOrganizationType, OrganizationId, ReportStatus)
GO

CREATE INDEX index_report_Misc3 ON Report (IsDeleted, OrganizationOrganizationType, OrganizationId)
GO

CREATE INDEX index_report_Misc4 ON Report (IsDeleted, OrganizationOrganizationType)
GO