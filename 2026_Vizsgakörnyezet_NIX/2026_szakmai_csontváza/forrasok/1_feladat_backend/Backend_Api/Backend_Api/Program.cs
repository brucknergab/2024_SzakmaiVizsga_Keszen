using Backend_Api.Data;
using Backend_Api.Interfaces;
using Backend_Api.Helpers;
using Backend_Api.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Szolgáltatások hozzáadása a konténerhez (DI - Dependency Injection)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Swagger beállítása a teszteléshez
builder.Services.AddSwaggerGen();

// CORS engedélyezése a frontend (Angular/React/Vue) számára
builder.Services.AddCors();

// --- ADATBÁZIS KAPCSOLAT BEÁLLÍTÁSA ---
// A DefaultConnection az appsettings.json-ből jön. Ellenőrizd, hogy az adatbázis-név megfelelő-e!
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


// --- AUTOMAPPER REGISZTRÁLÁSA ---

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AutoMapperProfiles>();
});


// --- SAJÁT SZOLGÁLTATÁSOK (SERVICES / REPOSITORIES) REGISZTRÁLÁSA ---

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IService, Service>();

var app = builder.Build();

// HTTP kérések feldolgozási lánca (Middleware-ek)

// CORS házirend beállítása
app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("http://localhost:4200"));

// Fejlesztői környezetben a Swagger (dokumentáció) engedélyezése
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Controllerek végpontjainak betöltése
app.MapControllers();

// Alkalmazás futtatása
app.Run();