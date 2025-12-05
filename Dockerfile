# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

# Copiar todo y restaurar
COPY . . 
RUN dotnet restore

# Publicar proyecto
RUN dotnet publish ./NatureAPI/NatureAPI.csproj -c Release -o /app/publish

# Etapa runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Dependencias opcionales (libgdiplus, wkhtmltopdf, etc.)
RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev wget fontconfig

WORKDIR /app
COPY --from=build-env /app/publish .

# Exponer puerto 80 como fallback
EXPOSE 80

# Ajuste permisos wkhtmltopdf (Rotativa)
RUN if [ -f /app/Rotativa/Linux/wkhtmltopdf ]; then chmod 755 /app/Rotativa/Linux/wkhtmltopdf; fi

# Ejecutar la API usando variable PORT de Render
ENTRYPOINT ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-80} dotnet NatureAPI.dll"]
