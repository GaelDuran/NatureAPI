# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

# Copiar y restaurar
COPY . . 
RUN dotnet restore

# Publicar proyecto
RUN dotnet publish ./NatureAPI/NatureAPI.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Dependencias opcionales
RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev wget fontconfig

WORKDIR /app
COPY --from=build-env /app/publish .

# Exponer puerto 80 (Render asigna el real vía $PORT)
EXPOSE 80

# Ajustar permisos si existe wkhtmltopdf
RUN if [ -f /app/Rotativa/Linux/wkhtmltopdf ]; then chmod 755 /app/Rotativa/Linux/wkhtmltopdf; fi

# Ejecutar API usando puerto dinámico
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-80} dotnet NatureAPI.dll"]
