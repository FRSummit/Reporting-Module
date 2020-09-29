ALTER TABLE ReportEventLog
DROP CONSTRAINT FK_ReportEventLog
GO

CREATE INDEX index_reporteventlog_reportid ON ReportEventLog (ReportId)
GO