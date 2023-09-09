using model;
using ParcialVisual.Data;
using ParcialVisual.Data.repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connection = new mysqlConfig(builder.Configuration.GetConnectionString("mysqlconnection"));
builder.Services.AddSingleton(connection);
builder.Services.AddScoped<iClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<iEmpleadosRepositorio, EmpleadosRepositorio>();
builder.Services.AddScoped<iVentasRepositorio, VentasRepositorio>();
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
