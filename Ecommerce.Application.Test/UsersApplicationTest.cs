using Ecommerce.Application.Interface;
using Ecommerce.Services.WebApi.Modules.Injection;
using Ecommerce.Services.WebApi.Modules.Mapper;
using Ecommerce.Services.WebApi.Modules.Validator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        // Inicializar configuración con variables de entorno
        // e inyección de dependencias para las pruebas unitarias
        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            // Crear un contenedor de servicios manualmente.
            var services = new ServiceCollection();
            // Configuración automapper
            services.AddMapper();
            // Configuracipon inyección de dependencias
            services.AddInjection();
            // Configuración fluent validation
            services.AddValidator();

            // Crear el proveedor de servicios y obtener `IServiceScopeFactory`.
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange: Donde se inicializan los objetos necesarios para la ejecución del código
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de validación";

            // Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            // Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange: Donde se inicializan los objetos necesarios para la ejecución del código
            var userName = "yeisson8a";
            var password = "123456";
            var expected = "La autenticación ha sido exitosa";

            // Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            // Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange: Donde se inicializan los objetos necesarios para la ejecución del código
            var userName = "yeisson8a";
            var password = "1234567891011121314";
            var expected = "El usuario no existe";

            // Act: Donde se ejecuta el método que se va a probar y se obtiene el resultado
            var result = context.Authenticate(userName, password);
            var actual = result.Message;

            // Assert: Donde se comprueba que el resultado obtenido es el esperado
            Assert.AreEqual(expected, actual);
        }
    }
}
