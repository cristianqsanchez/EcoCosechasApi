using System.Runtime.InteropServices;
using AutoMapper;
using EcoCosechas.DTOs;
using EcoCosechas.Models;
using EcoCosechas.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

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

app.UseHttpsRedirection();

app.MapGet("/products", async (IProductRepository repository, IMapper mapper) =>
{
    var products = await repository.List();
    var productsDTO = mapper.Map<List<ProductoDTO>>(products);
    return Results.Ok(productsDTO);
});

app.MapGet("/products/{id:int}", async (int id, IProductRepository repository, IMapper mapper) =>
{
    var product = await repository.GetById(id);

    if (product is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(product);
});

app.Run();