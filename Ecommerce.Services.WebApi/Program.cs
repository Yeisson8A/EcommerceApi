using Ecommerce.Services.WebApi.Modules.Authentication;
using Ecommerce.Services.WebApi.Modules.Feature;
using Ecommerce.Services.WebApi.Modules.Injection;
using Ecommerce.Services.WebApi.Modules.Mapper;
using Ecommerce.Services.WebApi.Modules.Swagger;
using Ecommerce.Services.WebApi.Modules.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Configuración automapper
builder.Services.AddMapper();
// Configuracipon inyección de dependencias
builder.Services.AddInjection();
// Configuración autenticación
builder.Services.AddAuthentication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Configuración swagger
builder.Services.AddSwagger();
// Configuración CORS
builder.Services.AddFeature(builder.Configuration);
// Configuración fluent validation
builder.Services.AddValidator();

var app = builder.Build();
app.UseCors("CorsRule");
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
