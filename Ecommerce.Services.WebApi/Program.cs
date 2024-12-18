using AutoMapper;
using Ecommerce.Application.Interface;
using Ecommerce.Application.Main;
using Ecommerce.Domain.Core;
using Ecommerce.Domain.Interface;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Interface;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Services.WebApi.Helpers;
using Ecommerce.Transversal.Common;
using Ecommerce.Transversal.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Agregar automapper
builder.Services.AddAutoMapper(x => x.AddProfile(new MappingsProfile()));
// Agregar instancia de conexión a la base de datos
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
// Configuración de los valores de la sección "Config" del appsettings.json
builder.Services.Configure<ConfigurationSettings>(builder.Configuration.GetSection("Config"));
// Agregar instancias de aplicación
builder.Services.AddScoped<ICustomersApplication, CustomersApplication>();
builder.Services.AddScoped<IUsersApplication, UsersApplication>();
// Agregar instancias de dominio
builder.Services.AddScoped<ICustomersDomain, CustomersDomain>();
builder.Services.AddScoped<IUsersDomain, UsersDomain>();
// Agregar instancias de repositorio
builder.Services.AddScoped<ICustomersRepository, CustomersRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitar CORS para acceso externo
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsRule", rule =>
    {
        rule.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration["Config:OriginCors"]);
    });
});

var app = builder.Build();
app.UseCors("CorsRule");
app.UseAuthentication();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
