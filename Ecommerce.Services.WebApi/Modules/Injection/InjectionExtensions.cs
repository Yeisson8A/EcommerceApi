using Ecommerce.Application.Interface;
using Ecommerce.Application.Main;
using Ecommerce.Domain.Core;
using Ecommerce.Domain.Interface;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Interface;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Transversal.Common;
using Ecommerce.Transversal.Logging;

namespace Ecommerce.Services.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            // Agregar instancia de conexión a la base de datos
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            // Agregar instancias de aplicación
            services.AddScoped<ICustomersApplication, CustomersApplication>();
            services.AddScoped<IUsersApplication, UsersApplication>();
            // Agregar instancias de dominio
            services.AddScoped<ICustomersDomain, CustomersDomain>();
            services.AddScoped<IUsersDomain, UsersDomain>();
            // Agregar instancias de repositorio
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            // Agregar inyección de dependencia Logger
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
