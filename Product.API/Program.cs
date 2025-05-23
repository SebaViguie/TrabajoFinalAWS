using Microsoft.EntityFrameworkCore;
using Product.Application.Services;
using Product.Domain.Repositories;
using Product.Infraestructure.Repositories;
using Product.Infraestructure.Data;
using Product.Application.Profiles;
using Serilog;
using Product.API.Middleware;
using FluentValidation;
using Product.Domain.Validations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddValidatorsFromAssemblyContaining<ProductValidator>();

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var loggingConfig = new LoggerConfiguration()
    .WriteTo.File("logs/serilog.txt",
                    rollingInterval: RollingInterval.Day)
    .MinimumLevel.Information()
    .CreateLogger();

builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(loggingConfig);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
