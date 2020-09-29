ECHO OFF

ECHO Migrating REPORTING_DEV database
ECHO.
ECHO.
pushd ..\\flyway.rm.inst

call .\flyway migrate

popd
