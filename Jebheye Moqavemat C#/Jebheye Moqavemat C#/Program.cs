using Application.Services;
using Domain.Interfaces.IDocumnets;
using Domain.Interfaces.IProducts;
using Domain.Interfaces.IWarehouses;
using Infrastructure.dbContext;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<dbContextDatabase>(ServiceLifetime.Scoped);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ISerialRepository , SerialRepository>();
//builder.Services.AddScoped<SerialService>();
builder.Services.AddScoped<IDocumnetRepository, DocumnetRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IShelfRepository, ShelfRepository>();
////////////////////////////////////////////
builder.Services.AddScoped<ShelfService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<CityService>();
//builder.Services.AddScoped<DocumnetService>();
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
