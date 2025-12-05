# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

# Copiar todo y restaurar
COPY . . 
RUN dotnet restore

# Publicar la API
RUN dotnet publish ./NatureAPI/NatureAPI.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Dependencias opcionales
RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev wget fontconfig

WORKDIR /app
COPY --from=build-env /app/publish .

EXPOSE 80

# Ejecutar la API en el puerto de Render
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-80} dotnet NatureAPI.dll"]
