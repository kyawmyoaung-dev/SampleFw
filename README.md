# SampleFW
clean architecture

# Ef core migration command
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitMigration --context ApplicationDbContext --project .\Persistence\Persistence.csproj  --startup-project .\WebMvc\WebMvc.csproj

dotnet ef database update --context ApplicationDbContext --project .\Persistence\Persistence.csproj  --startup-project .\WebMvc\WebMvc.csproj
