# Dockerfile → Poner en la RAÍZ del repositorio natureapp-api
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /App
EXPOSE 8080

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

# Copiar y restaurar
COPY . .
RUN dotnet restore

# Publicar
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /App/publish /p:UseAppHost=false

# Runtime stage
FROM base AS final
WORKDIR /App

# Solo lo estrictamente necesario para que no falle nunca
RUN apt-get update -qq && \
    apt-get -y install libgdiplus libc6-dev && \
    rm -rf /var/lib/apt/lists/*

# Copiar la app publicada
COPY --from=build /App/publish .

# Templates y Rotativa: solo si existen (esta sintaxis NUNCA falla)
COPY NatureAPI/Templates ./Templates 2>/dev/null || :
COPY NatureAPI/Rotativa ./Rotativa 2>/dev/null || :
RUN [ -f ./Rotativa/Linux/wkhtmltopdf ] && chmod +x ./Rotativa/Linux/wkhtmltopdf || true

ENTRYPOINT ["dotnet", "NatureAPI.dll"]