using Ecommerce.Services.WebApi.Modules.Authentication;
using Ecommerce.Services.WebApi.Modules.Feature;
using Ecommerce.Services.WebApi.Modules.Injection;
using Ecommerce.Services.WebApi.Modules.Mapper;
using Ecommerce.Services.WebApi.Modules.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Configuraci�n automapper
builder.Services.AddMapper();
// Configuracipon inyecci�n de dependencias
builder.Services.AddInjection();
// Configuraci�n autenticaci�n
builder.Services.AddAuthentication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Configuraci�n swagger
builder.Services.AddSwagger();
// Configuraci�n CORS
builder.Services.AddFeature(builder.Configuration);

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
