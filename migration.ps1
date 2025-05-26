param (
	$migrationName,
	[switch]$add = $false,
	[switch]$remove = $false,
	[switch]$updateDB = $false
)

if ($add)
{
	if($migrationName -eq $null)
	{
		Write-Host "missing -migrationName parameter"
		exit
	}
	dotnet ef migrations add $migrationName -s src/BookStore.Server
	dotnet ef migrations script -s src/BookStore.Server  -o src/BookStore.Server/Migrations/SQL/Migration.sql --idempotent
}
if($remove)
{
	dotnet ef migrations remove -s src/BookStore.Server
	dotnet ef migrations script -s src/BookStore.Server  -o src/BookStore.Server/Migrations/SQL/Migration.sql --idempotent
}
if($updateDB)
{
	if ($migrationName -eq $null) {
		dotnet ef database update -s src/BookStore.Server
	} else {
		dotnet ef database update -s src/BookStore.Server
	}
}