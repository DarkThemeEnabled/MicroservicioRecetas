using Application.Interfaces;
using Application.UseCases.SDificultad;
using Application.UseCases.SJson;
using Application.UseCases.SPasos;
using Application.UseCases.SReceta;
using Infraestructure.Command;
using Infraestructure.Persistence.Config;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom
var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddDbContext<RecetasContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IDificultadService, DificultadService>();
builder.Services.AddScoped<IDificultadQuery, DificultadQuery>();

builder.Services.AddScoped<IRecetaService, RecetaService>();
builder.Services.AddScoped<IRecetaQuery, RecetaQuery>();
builder.Services.AddScoped<IRecetaCommand, RecetaCommand>();

builder.Services.AddScoped<IPasosService, PasosService>();
builder.Services.AddScoped<IPasosCommand,PasosCommand>();
//builder.Services.AddScoped<IViajeServicioService, ViajeServicioService>();
//builder.Services.AddScoped<IViajeServicioQuery, ViajeServicioQuery>();
//builder.Services.AddScoped<IViajeServicioCommand, ViajeServicioCommand>();

//builder.Services.AddScoped<IServicioService, ServicioService>();
//builder.Services.AddScoped<IServicioQuery, ServicioQuery>();
//builder.Services.AddScoped<IServicioCommand, ServicioCommand>();

//CORS deshabilitar
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
