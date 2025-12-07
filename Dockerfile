FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App

COPY . ./

# Copia explícitamente appsettings a la carpeta correcta por si está fuera
COPY ./appsettings.json ./NatureAPI/appsettings.json

RUN dotnet restore
RUN dotnet publish NatureAPI/NatureAPI.csproj -c Release -o /App/build

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App

RUN apt-get update -qq && apt-get -y install libgdiplus libc6-dev 
RUN apt-get update && apt-get install -y wget fontconfig

RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v
    
COPY --from=build-env /App/build .

ENTRYPOINT ["dotnet", "NatureAPI.dll"]
