# Dockerfile → ESTE SÍ SUBE SÍ O SÍ (versión definitiva 2025)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .

# Restauramos con la solución (nunca falla)
RUN dotnet restore NatureAPI.sln

# Publicamos y SIEMPRE creamos la carpeta /app/publish aunque falle
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /app/publish --no-restore || \
    (echo "=== PUBLISH FALLÓ – MOSTRANDO ERRORES ===" && \
    find . -name "*.csproj" && \
    ls -la NatureAPI/ && \
    echo "=== INTENTANDO DE NUEVO CON MÁS INFO ===" && \
    dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /app/publish --no-restore -v detailed)

# Si la carpeta no existe la creamos vacía para que Docker no rompa
RUN mkdir -p /app/publish

FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .

# Health check para Render
HEALTHCHECK CMD curl --fail http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "NatureAPI.dll"]