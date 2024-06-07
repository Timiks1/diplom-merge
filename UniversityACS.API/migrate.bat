dotnet-ef database drop --force
dotnet-ef migrations remove
dotnet-ef migrations add initial
dotnet-ef database update
