using EcoCosechas.Models;
using EcoCosechas.Repositories;
using Microsoft.EntityFrameworkCore;
using EcoCosechas.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var allowOrigins = builder.Configuration.GetValue<string>("allowOrigins")!;

builder.Services.AddDbContext<EcoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(configuracion =>
    {
        configuracion.WithOrigins(allowOrigins).AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapGroup("/products").MapProducts();

app.Run();