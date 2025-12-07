FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

# Copiar todo el repo
COPY . .

# Restaurar
RUN dotnet restore NatureAPI/NatureAPI.csproj

# Publicar
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Fuentes y dependencias visuales
RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev wget fontconfig

RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v

# Copiar app publicado
COPY --from=build-env /app/publish .

ENTRYPOINT ["dotnet", "NatureAPI.dll"]
