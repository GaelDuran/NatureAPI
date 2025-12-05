# Dockerfile → RAÍZ del repositorio natureapp-api
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .

# Restaurar todos los proyectos que encuentre
RUN dotnet restore

# Publicar TODOS los proyectos y copiar solo la salida del que tenga <OutputType>Exe</OutputType>
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM runtime AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "NatureAPI.dll"]