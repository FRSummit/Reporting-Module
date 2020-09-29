ECHO OFF

ECHO Migrating REPORTING_QAS database
ECHO.
ECHO.
pushd ..\\flyway.rm.inst

call .\flyway -url=jdbc:jtds:sqlserver://localhost:1433/REPORTING_QAS migrate

popd
