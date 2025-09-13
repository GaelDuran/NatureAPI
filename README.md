NatureAPI:

NatureAPI es una API REST construida con .NET 8 que te permite gestionar lugares naturales de México como parques, cascadas, miradores y senderos.
La idea es centralizar información de cada lugar con sus coordenadas, fotos, reseñas y amenidades, para hacer más fácil explorar y administrar estos espacios.

✨ Características principales:
CRUD completo de lugares naturales (parques, cascadas, miradores, senderos).
Relación con senderos, fotos, reseñas y amenidades.
Base de datos SQL Server en Docker lista para usarse.
Migraciones y datos iniciales con EF Core.
Endpoints RESTful con soporte para filtros.
Documentación automática con Swagger.

🏗️ Entidades
Place → Lugar natural principal (parque, cascada, mirador, sendero).
Trail → Senderos o rutas asociadas a un lugar.
Photo → Imágenes vinculadas a un lugar.
Review → Opiniones de visitantes.
Amenity → Servicios o amenidades disponibles en un lugar.

🔧 Requisitos previos
.NET 8 SDK
Docker
SQL Server Management Studio o Azure Data Studio

🚀 Instalación y ejecución

Clona el repositorio:
git clone <URL_DEL_REPO>
cd NatureAPI


Levanta SQL Server en Docker:
Crea un archivo compose.yaml con este contenido:

services:
  db:
    image: mcr.microsoft.com/mssql/server:2022-latest
    container_name: SQL_Server
    ports:
      - 1434:1433
    environment:
      - MSSQL_SA_PASSWORD=Abc12345!
      - ACCEPT_EULA=Y
      - MSSQL_PID=Developer
    volumes:
      - sql_server_data:/var/opt/mssql
volumes:
  sql_server_data:


Luego, ejecuta:
docker compose -f compose.yaml up -d

Aplica migraciones y seed:

dotnet ef database update --project ./NatureAPI/NatureAPI.csproj --startup-project ./NatureAPI/NatureAPI.csproj

🌐 Uso de la API

GET /api/places → Lista todos los lugares (con filtros por categoría y dificultad).
GET /api/places/{id} → Obtiene el detalle de un lugar.
POST /api/places → Crea un nuevo lugar (con validación de coordenadas).

📖 Para explorar los endpoints de manera interactiva, abre en tu navegador:
http://localhost:{puerto}/swagger

📂 Migraciones y seed

Las migraciones se guardan en NatureAPI/Migrations.
Los datos iniciales se aplican automáticamente al ejecutar:

dotnet ef database update
