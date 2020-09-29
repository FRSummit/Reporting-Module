DATABASE SCRIPT USAGE

=====================================================================================
createdb.sql

example usage:
> sqlcmd -v dbname=test2 dblocation="d:\data\temp" -i createdb.sql

description:
Specify the database name and its location as sqlcmd variables, then calls the createdb.sql script.
The database will be created in the default sql instance.


=====================================================================================
dropdb.sql

example usage:
> sqlcmd -v dbname=test2 -i dropdb.sql

description:
Will delete the specified database from the default sql instance.

