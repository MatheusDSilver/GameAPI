using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace GameAPI.Infrastructure.Migrations
{
    //Classe para migração do banco de dados
    //Caso o schema não exista, ele é criado utilizando o Dapper
    public class DatabaseMigration
    {
        public static void Migrate(string connectionString, IServiceProvider service)
        {
            EnsureDatabaseCreated(connectionString);

            MigrationDatabase(service);
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

        private static void MigrationDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            runner.ListMigrations();

            runner.MigrateUp();
        }
    }
}
