using Microsoft.Extensions.Configuration;

namespace GameAPI.Infrastructure.Extensions
{
    //Quando precisar da connectionString, basta chamar o método static ConnectionString da classe
    public static class ConfigurationExtensions
    {
        public static string ConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection")!;
        }
    }
}
