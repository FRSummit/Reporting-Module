IF NOT EXISTS (
SELECT  schema_name
FROM    information_schema.schemata
WHERE   schema_name = 'nsb' )
BEGIN
	EXEC sp_executesql N'create schema nsb'
END