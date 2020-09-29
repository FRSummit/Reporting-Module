ECHO OFF

ECHO Migrating REPORTING_TEST database
ECHO.
ECHO.
pushd ..\\flyway.rm.inst

call .\flyway -configFiles=conf\flyway_test.conf migrate

popd
