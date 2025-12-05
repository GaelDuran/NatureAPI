# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

# Copiar todo y restaurar dependencias
COPY . . 
RUN dotnet restore

# Publicar la aplicación
RUN dotnet publish ./NatureAPI/NatureAPI.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app
COPY --from=build-env /app/publish .

# Instalar dependencias opcionales (libgdiplus, fontconfig, wget)
RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev wget fontconfig

# Exponer puerto 80 (Render usa $PORT)
EXPOSE 80

# Ejecutar la API usando la variable de entorno PORT de Render
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-80} dotnet NatureAPI.dll"]
