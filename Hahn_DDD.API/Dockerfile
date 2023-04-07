#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hahn_DDD.API/Hahn.DDD.API.csproj", "Hahn_DDD.API/"]
COPY ["Hahn.DDD.Application/Hahn.DDD.Application.csproj", "Hahn.DDD.Application/"]
COPY ["Hahn_DDD.Domain/Hahn.DDD.Domain.csproj", "Hahn_DDD.Domain/"]
COPY ["Hahn.DDD.Infrastructure/Hahn.DDD.Infrastructure.csproj", "Hahn.DDD.Infrastructure/"]
RUN dotnet restore "Hahn_DDD.API/Hahn.DDD.API.csproj"
COPY . .
WORKDIR "/src/Hahn_DDD.API"
RUN dotnet build "Hahn.DDD.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hahn.DDD.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hahn.DDD.API.dll"]