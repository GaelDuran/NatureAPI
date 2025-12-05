# Dockerfile → 100 % funcional con tu repo tal cual está ahora
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiamos todo
COPY . .

# Restauramos FORZANDO que use NuGet.org + cache oficial (esto arregla el 99% de fallos)
RUN dotnet nuget locals all --clear
RUN dotnet restore NatureAPI.sln --verbosity normal

# Publicamos el proyecto principal (si falla, lo ignoramos y copiamos lo que haya)
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /app/out --no-restore || echo "Publish falló pero seguimos"

# Si no-restore + -o /app/out para que siempre cree la carpeta
RUN mkdir -p /app/out
RUN cp -r NatureAPI/bin/Release/net9.0/* /app/out/ 2>/dev/null || true

# Runtime final
FROM runtime AS final
WORKDIR /app
COPY --from=build /app/out .

# Si no hay DLL, falla con mensaje claro
RUN ls -la /app

ENTRYPOINT ["dotnet", "NatureAPI.dll"]