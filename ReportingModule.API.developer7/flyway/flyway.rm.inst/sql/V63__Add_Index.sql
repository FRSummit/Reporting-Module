
CREATE INDEX index_report_Misc5 ON Report (IsDeleted, OrganizationOrganizationType, Id)
GO

CREATE INDEX index_organization_parentid ON Organization (IsDeleted, ParentId)
GO
