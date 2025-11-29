FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

# Copiar todo y restaurar
COPY . .
RUN dotnet restore

# Publicar el proyecto NatureAPI
RUN dotnet publish ./NatureAPI/NatureAPI.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Dependencias opcionales para procesamiento de imágenes / wkhtmltopdf
RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev wget fontconfig

WORKDIR /app
COPY --from=build-env /app/publish .

# Bind a puerto 80 (útil en Render)
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Si existe wkhtmltopdf en Rotativa, ajustar permisos
RUN if [ -f /app/Rotativa/Linux/wkhtmltopdf ]; then chmod 755 /app/Rotativa/Linux/wkhtmltopdf; fi

ENTRYPOINT ["dotnet", "NatureAPI.dll"]
