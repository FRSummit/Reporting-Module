---/*Here the script to clear the database:*/
---/*
---DECLARE @SQL AS VarChar(MAX)
---SET @SQL = ''
---SELECT @SQL = @SQL + 'Select * FROM ' + TABLE_SCHEMA + '.[' + TABLE_NAME + ']' + CHAR(13) FROM INFORMATION_SCHEMA.TABLES
---where TABLE_NAME not in ('Organization', 'OrganizationUser', 'flyway_schema_history', 'Identifier')
---exec (@SQL)
---*/

/*
DECLARE @SQL AS VarChar(MAX)
SET @SQL = ''
SELECT @SQL = @SQL + 'DELETE FROM ' + TABLE_SCHEMA + '.[' + TABLE_NAME + ']' + CHAR(13) FROM INFORMATION_SCHEMA.TABLES
where TABLE_NAME not in ('flyway_schema_history', 'Identifier', 'UnitReportView', 'StateReportView')
exec (@SQL)
GO
*/
DECLARE @SQL AS VarChar(MAX)
SET @SQL = ''
SELECT @SQL = @SQL + 'truncate table ' + TABLE_SCHEMA + '.[' + TABLE_NAME + ']' + CHAR(13) FROM INFORMATION_SCHEMA.TABLES
where TABLE_NAME not in ('flyway_schema_history', 'Identifier', 'UnitReportView', 'StateReportView', 'AllReportView')
exec (@SQL)
GO
