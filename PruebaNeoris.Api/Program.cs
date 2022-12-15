global using PruebaNeoris.Repository.Context;
global using Microsoft.EntityFrameworkCore;
using PruebaNeoris.Entities.Interfaces;
using PruebaNeoris.Services;
using PruebaNeoris.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IClientesServices, ClientesServices>();
builder.Services.AddTransient<ICuentasServices, CuentasServices>();
builder.Services.AddTransient<IMovimientosServices, MovimientosServices>();
builder.Services.AddTransient<IPersonasRepository, PersonasRepository>();
builder.Services.AddTransient<IClientesRepository, ClientesRepository>();
builder.Services.AddTransient<ICuentasRepository, CuentasRepository>();
builder.Services.AddTransient<IMovimientosRepository, MovimientosRepository>();

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PruebaNeoris"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
