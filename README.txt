dotnet new webapi 

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package AutoMapper --version 11.0.1

# Migrations

## migration command

--initial
dotnet ef migrations add AddInitial

--to execute database
dotnet ef database update