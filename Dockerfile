# Dockerfile → RAÍZ del repositorio natureapp-api
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App

# Copiar todo
COPY . ./

# Restaurar y publicar (exactamente como en tu proyecto que funcionó)
RUN dotnet restore
RUN dotnet publish NatureAPI/NatureAPI.csproj publish -c Release -o /App/build

# Imagen final
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App

# Instalar solo lo básico para que no falle si usas PDFs alguna vez
RUN apt-get update -qq && \
    apt-get -y install libgdiplus libc6-dev && \
    rm -rf /var/lib/apt/lists/*

# Fuentes Poppins (opcional, pero como ya lo tenías...)
RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -q -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf \
    https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -q -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf \
    https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v

# Copiar la app publicada
COPY --from=build-env /App/build .

# Copiar Templates si existen (no falla si no están)
COPY NatureAPI/Templates ./Templates 2>/dev/null || echo "No Templates folder"

# Si en algún momento subes Rotativa, que no dé error (pero no es obligatorio)
COPY NatureAPI/Rotativa ./Rotativa 2>/dev/null || echo "No Rotativa folder"
RUN if [ -f ./Rotativa/Linux/wkhtmltopdf ]; then chmod +x ./Rotativa/Linux/wkhtmltopdf; fi

# Render necesita que escuches en el puerto que te da o en 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "NatureAPI.dll"]