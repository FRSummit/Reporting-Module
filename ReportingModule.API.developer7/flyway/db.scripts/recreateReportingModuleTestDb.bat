ECHO OFF

ECHO Wiping and re-initializing a blank REPORTING_TEST database
ECHO.
ECHO.
pushd ..\\flyway.rm.inst

ECHO ===================================================================================
ECHO STEP 1: CLEAN DATABASE CONTENTS
call .\flywayAdmin clean

ECHO ===================================================================================
ECHO STEP 2: MIGRATING DATABASE FROM VERSION 1
call .\flyway migrate

ECHO ===================================================================================
popd

ECHO DONE
