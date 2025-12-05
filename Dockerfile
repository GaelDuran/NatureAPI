# Dockerfile → Poner en la RAÍZ del repositorio natureapp-api
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Render obliga a usar el puerto que te inyecta, pero 8080 funciona perfecto
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar solo el csproj primero (mejor cache)
COPY NatureAPI/NatureAPI.csproj NatureAPI/
RUN dotnet restore NatureAPI/NatureAPI.csproj

# Copiar todo el código
COPY . .

# Publicar
WORKDIR /src/NatureAPI
RUN dotnet publish NatureAPI.csproj -c Release -o /app/publish /p:UseAppHost=false

# Imagen final (muy ligera)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Templates (si existen → no falla si no están)
RUN mkdir -p /app/Templates
COPY NatureAPI/Templates/ /app/Templates/ 2>/dev/null || echo "No hay carpeta Templates"

# Entrypoint
ENTRYPOINT ["dotnet", "NatureAPI.dll"]