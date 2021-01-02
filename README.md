# Clean Architecture
## Architecture & Design
  - Domain Layer
  - Application Layer
  - Persistence Layer
  - Infrastructure Layer
  - Presentation Layer
## Tools
  - Visual studio 2019
  - MSSQL2019
  - dotnet core 3.1 LTS
  - dotnet standard 2.1

## Ef core migration command
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitMigration --context ApplicationDbContext --project .\Persistence\Persistence.csproj  --startup-project .\WebMvc\WebMvc.csproj

dotnet ef database update --context ApplicationDbContext --project .\Persistence\Persistence.csproj  --startup-project .\WebMvc\WebMvc.csproj
