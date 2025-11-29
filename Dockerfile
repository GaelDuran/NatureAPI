# dockerfile actualizado para .NET 9
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App

# Copia todo
COPY . ./

# Restore y publish
RUN dotnet restore ./NatureAPI/NatureAPI.csproj
RUN dotnet publish ./NatureAPI/NatureAPI.csproj -c Release -o /App/build

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

# Dependencias opcionales
RUN apt-get update -qq && apt-get install -y --no-install-recommends \
    libgdiplus libc6-dev wget fontconfig ca-certificates \
    && rm -rf /var/lib/apt/lists/*

# Fuentes
RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -q -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -q -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v || true

WORKDIR /App

# Copiar build final
COPY --from=build-env /App/build .

# Ajuste Rotativa (opcional)
RUN if [ -f /App/Rotativa/Linux/wkhtmltopdf ]; then chmod 755 /App/Rotativa/Linux/wkhtmltopdf; fi

ENTRYPOINT ["dotnet", "NatureAPI.dll"]
