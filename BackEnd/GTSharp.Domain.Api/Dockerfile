#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
ENV ASPNETCORE_URLS=http://+:5000
COPY ["GTSharp.Domain.Api/GTSharp.Domain.Api.csproj", "GTSharp.Domain.Api/"]
COPY ["GTSharp.Domain.Infra/GTSharp.Domain.Infra.csproj", "GTSharp.Domain.Infra/"]
COPY ["GTSharp.Domain/GTSharp.Domain.csproj", "GTSharp.Domain/"]
RUN dotnet restore "GTSharp.Domain.Api/GTSharp.Domain.Api.csproj"
COPY . .
WORKDIR "/src/GTSharp.Domain.Api"
RUN dotnet build "GTSharp.Domain.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "GTSharp.Domain.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GTSharp.Domain.Api.dll"]
