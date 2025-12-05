# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Default environment for production (will be overridden at runtime by Render via $PORT)
ENV ASPNETCORE_ENVIRONMENT=Production

# Instalar solo lo necesario para Rotativa (wkhtmltopdf)
RUN apt-get update && apt-get install -y \
    libgdiplus \
    libc6-dev \
    wget \
    fontconfig \
    ca-certificates \
    && rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["NatureAPI/NatureAPI.csproj", "NatureAPI/"]
RUN dotnet restore "NatureAPI/NatureAPI.csproj"

COPY . .
WORKDIR "/src/NatureAPI"
RUN dotnet build "NatureAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NatureAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/NatureAPI/Templates ./Templates
COPY --from=build /src/NatureAPI/Rotativa ./Rotativa

# Permisos wkhtmltopdf si existe
RUN if [ -f ./Rotativa/Linux/wkhtmltopdf ]; then chmod +x ./Rotativa/Linux/wkhtmltopdf; fi

# Use the PORT env var provided by Render at runtime; fall back to 8080
CMD ["sh", "-c", "ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080} dotnet NatureAPI.dll"]
