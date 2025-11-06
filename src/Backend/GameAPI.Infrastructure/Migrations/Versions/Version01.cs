using FluentMigrator;

namespace GameAPI.Infrastructure.Migrations.Versions
{
    [Migration(1, "Create table to save player's informations")]
    public class Version01 : ForwardOnlyMigration
    {
        public override void Up()
        {
            const string schema = "gameapi";

            Create.Table("players").InSchema(schema)
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Username").AsString(100).NotNullable()
                .WithColumn("Stats_Level").AsInt32().NotNullable().WithDefaultValue(1)
                .WithColumn("Stats_Experience").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Stats_Health").AsInt32().NotNullable().WithDefaultValue(100);
        }
    }
}
