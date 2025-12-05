using Microsoft.EntityFrameworkCore;
using NatureAPI.Data;
using NatureAPI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// JSON options
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// CORS
const string frontendOrigin = "http://localhost:4200";
const string corsPolicyName = "AllowFrontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, policy =>
    {
        policy.WithOrigins(frontendOrigin)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Swagger / API explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (asegúrate de tener ConnectionStrings:DefaultConnection en appsettings.json)
// Cambiado a Npgsql + NetTopologySuite para compatibilidad con PostgreSQL/PostGIS en Render
builder.Services.AddDbContext<NatureDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.UseNetTopologySuite()));

// Servicios
builder.Services.AddScoped<OpenAIService>();

var app = builder.Build();

// Aplicar migraciones al arranque (seguro para production si tienes backups)
using (var scope = app.Services.CreateScope())
{
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<NatureDbContext>();
        db.Database.Migrate();
        logger.LogInformation("Aplicadas migraciones de la base de datos.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Error aplicando migraciones al arranque");
        // No relanzar: permitimos que la app arranque para que Render pueda mostrar logs y puedas depurar.
    }
}

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Health endpoint requerido por Render
app.MapGet("/health", () => Results.Ok(new { status = "OK", time = DateTime.UtcNow }));

app.UseCors(corsPolicyName);
app.UseAuthorization();
app.MapControllers();
app.Run();