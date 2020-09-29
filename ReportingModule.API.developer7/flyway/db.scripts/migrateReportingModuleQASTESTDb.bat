ECHO OFF

ECHO Migrating REPORTING_QAS_TEST database
ECHO.
ECHO.

pushd

call flyway -configFiles=flyway/flyway.rm.inst/conf/flyway_qas_test.conf migrate

popd