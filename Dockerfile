# Dockerfile → RAÍZ del repositorio natureapp-api
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /App
EXPOSE 8080

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
ENV ASPNETCORE_ENVIRONMENT=Production

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App

COPY . ./
RUN dotnet restore

# Publicar el proyecto NatureAPI
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /App/build /p:UseAppHost=false

# Runtime stage
FROM base AS final
WORKDIR /App

# Dependencias mínimas para Rotativa (si algún día la subes)
RUN apt-get update -qq && \
    apt-get -y install libgdiplus libc6-dev && \
    rm -rf /var/lib/apt/lists/*

# Fuentes Poppins (opcional)
RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -q -O /usr/share/fonts/poppins/Poppins-Regular.ttf \
      https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -q -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf \
      https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v

# Copiar app publicada
COPY --from=build-env /App/build .

# Templates → si no existe, no falla
RUN mkdir -p /App/Templates
COPY NatureAPI/Templates/ /App/Templates/ || true

# Rotativa → si no existe, no falla (y nunca más dará el error de comillas)
RUN mkdir -p /App/Rotativa
COPY NatureAPI/Rotativa/ /App/Rotativa/ || true
RUN if [ -f /App/Rotativa/Linux/wkhtmltopdf ]; then chmod +x /App/Rotativa/Linux/wkhtmltopdf; fi

ENTRYPOINT ["dotnet", "NatureAPI.dll"]