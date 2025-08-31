@echo off
setlocal

set "startupProject=..\..\BillSplit.API"
set "infrastructureProject=..\..\BillSplit.Infrastructure"

if "%~1"=="" (
    echo Error: Please provide the name of the migration to revert to.
    echo Usage: revert-migration.bat [PreviousMigrationName]
    goto :end
)

set "targetMigration=%~1"

echo Reverting database to the state of migration: %targetMigration%
dotnet ef database update %targetMigration% --project %infrastructureProject% --startup-project %startupProject%

if %errorlevel% neq 0 (
    echo An error occurred while reverting the database.
    goto :end
)

echo Removing the last migration file...
dotnet ef migrations remove --project %infrastructureProject% --startup-project %startupProject%

if %errorlevel% neq 0 (
    echo An error occurred while removing the migration file.
    goto :end
)

echo Done! The database has been reverted and the last migration file has been removed.
:end
pause
endlocal