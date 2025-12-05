# Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /src

# Copiar todo el repositorio
COPY . ./

# Asegurar que los directorios existen para evitar fallos en la etapa final
RUN mkdir -p /src/NatureAPI/Rotativa /src/NatureAPI/Templates

# Restaurar y publicar solo el proyecto NatureAPI
RUN dotnet restore "NatureAPI/NatureAPI.csproj"
RUN dotnet publish "NatureAPI/NatureAPI.csproj" -c Release -o /app/publish

# Imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Instalar dependencias para generación de PDFs y fuentes
RUN apt-get update && \
    apt-get install -y --no-install-recommends libgdiplus libc6-dev wget fontconfig ca-certificates && \
    rm -rf /var/lib/apt/lists/*

# Instalar fuentes Poppins (opcional, usado por la app)
RUN mkdir -p /usr/share/fonts/truetype/poppins && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Regular.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Regular.ttf && \
    wget -O /usr/share/fonts/truetype/poppins/Poppins-Bold.ttf https://github.com/google/fonts/raw/main/ofl/poppins/Poppins-Bold.ttf && \
    fc-cache -f -v

WORKDIR /app

# Copiar los artefactos publicados
COPY --from=build-env /app/publish .

# Copiar plantillas si existen en `NatureAPI/Templates`
COPY --from=build-env /src/NatureAPI/Templates /app/Templates

# Copiar Rotativa si se usa y ajustar permisos (si existe)
COPY --from=build-env /src/NatureAPI/Rotativa /app/Rotativa
RUN if [ -f /app/Rotativa/Linux/wkhtmltopdf ]; then chmod 755 /app/Rotativa/Linux/wkhtmltopdf; fi

ENTRYPOINT ["dotnet", "NatureAPI.dll"]
