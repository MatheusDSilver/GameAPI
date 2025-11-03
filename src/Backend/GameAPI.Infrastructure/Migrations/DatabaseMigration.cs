using Dapper;
using MySqlConnector;

namespace GameAPI.Infrastructure.Migrations
{
    //Classe para migração do banco de dados
    //Caso o schema não exista, ele é criado utilizando o Dapper
    public class DatabaseMigration
    {
        public static void Migrate(string connectionString)
        {
            EnsureDatabaseCreated(connectionString);
        }

        private static void EnsureDatabaseCreated(string connectionString)
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder(connectionString);

            var databaseName = connectionStringBuilder.Database;

            connectionStringBuilder.Remove("Database");

            using var dbConnection = new MySqlConnection(connectionStringBuilder.ConnectionString);

            var parameters = new DynamicParameters();
            parameters.Add("name", databaseName);

            var records = dbConnection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", parameters);
            
            if(records.Any() == false)
            {
                dbConnection.Execute($"CREATE DATABASE {databaseName}");
            }
        }
    }
}
