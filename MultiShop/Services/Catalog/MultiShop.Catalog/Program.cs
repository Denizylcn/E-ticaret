using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.CategoryService;
using MultiShop.Catalog.Services.ProductImageService;
using MultiShop.Catalog.Services.ProductService;
using MultiShop.Catalog.Services.ProductDetailService;
using System.Reflection;
using MultiShop.Catalog.Settings;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
//Dependency Injection Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
//Dependency Injection Services
//AutoMapper  Services
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//AutoMapper  Services
//DB Services
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
//DB Services
builder.Services.AddControllers();
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
