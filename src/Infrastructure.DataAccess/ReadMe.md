dotnet ef migrations add AddInitProject --project src\Infrastructure.DataAccess\Infrastructure.DataAccess.csproj --startup-project src\WebApi\WebApi.csproj --context ApplicationDbContext

dotnet ef database update --project src\Infrastructure.DataAccess\Infrastructure.DataAccess.csproj --context ApplicationDbContext --startup-project src\WebApi\WebApi.csproj

dotnet ef migrations remove --project src\Infrastructure.DataAccess\Infrastructure.DataAccess.csproj --startup-project src\WebApi\WebApi.csproj --context ApplicationDbContext