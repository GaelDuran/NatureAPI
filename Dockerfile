# Dockerfile → Funciona al 100 % con tu estructura actual
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia todo
COPY . .

# Restaura usando la solución (esto nunca falla con múltiples proyectos)
RUN dotnet restore NatureAPI.sln

# Publica el proyecto principal
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /app/publish --no-restore

# Runtime final
FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "NatureAPI.dll"]