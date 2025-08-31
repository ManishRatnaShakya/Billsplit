@echo off
setlocal
set "startupProject=..\..\BillSplit.API"
set "infrastructureProject=..\..\BillSplit.Infrastructure"

if "%~1"=="" (
    echo Error: Please provide a name for the new migration.
    echo Usage: add-migration.bat [MigrationName]
    goto :end
)

set "migrationName=%~1"

echo Adding a new migration: %migrationName%
dotnet ef migrations add %migrationName% --project %infrastructureProject% --startup-project %startupProject%

if %errorlevel% neq 0 (
    echo An error occurred while adding the migration.
    goto :end
)

echo Updating the database with the new migration...
dotnet ef database update --project %infrastructureProject% --startup-project %startupProject%

if %errorlevel% neq 0 (
    echo An error occurred while updating the database.
    goto :end
)

echo Done! The database has been successfully migrated with '%migrationName%'.
:end
pause
endlocal