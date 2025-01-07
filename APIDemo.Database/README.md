# Create a Migration
dotnet ef --startup-project .\APIDemo.API\APIDemo.API.csproj migrations add NEW_MIGRATION -p APIDemo.Database\APIDemo.Database.csproj -o Migrations --context APIDemoContext

# Update Database
dotnet ef --startup-project .\APIDemo.API\APIDemo.API.csproj --project APIDemo.Database\APIDemo.Database.csproj database update --context APIDemoContext

# Generate Migration SQL
dotnet ef --startup-project .\APIDemo.API\APIDemo.API.csproj --project APIDemo.Database\APIDemo.Database.csproj migrations script --context APIDemoContext > migration.sql