CREATE DATABASE [$(dbname)]
ON PRIMARY (
  NAME = dbName_dat,
  FILENAME = N'$(dblocation)\$(dbname)_1.mdf'
)
LOG ON (
  NAME = dbName_log,
  FILENAME = N'$(dblocation)\$(dbname)_1.ldf'
)
