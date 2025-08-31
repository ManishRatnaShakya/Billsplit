@echo off
setlocal

set "startupProject=..\..\BillSplit.API"
set "infrastructureProject=..\..\BillSplit.Infrastructure"

echo Updating the database with any pending migrations...
dotnet ef database update --project %infrastructureProject% --startup-project %startupProject%

if %errorlevel% neq 0 (
    echo An error occurred while updating the database.
    goto :end
)

echo Done! The database has been successfully updated.
:end
pause
endlocal