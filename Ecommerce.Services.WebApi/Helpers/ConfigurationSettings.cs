namespace Ecommerce.Services.WebApi.Helpers
{
    public class ConfigurationSettings
    {
        public string OriginCors { get; set; }

        public string Secret {  get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }
    }
}
