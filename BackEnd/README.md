# Api Leader Board

## Technologies
EFCore 3
EntityFrameworkCore 3.1.2
SQLite

## Compilation/Execution

- Compilation
```sh
dotnet restore .\APIASPNETCoreCQRSEFCore.sln
dotnet build .\APIASPNETCoreCQRSEFCore.sln
```

- DataBase
```sh
dotnet ef migrations add InitialCreate --startup-project ..\GTSharp.Domain.Api\
dotnet ef database update  --startup-project ..\GTSharp.Domain.Api\
```

- Execution
```sh
cd .\GTSharp.Domain.Api\
dotnet run watch
```
