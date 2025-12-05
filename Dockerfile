# Dockerfile → RAÍZ del repositorio natureapp-api
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /App
EXPOSE 8080

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .
RUN dotnet restore
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime
FROM base AS final
WORKDIR /App

# Solo lo imprescindible
RUN apt-get update -qq && apt-get install -y libgdiplus && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "NatureAPI.dll"]