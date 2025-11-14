using GameAPI.API.Filters;
using GameAPI.Application;
using GameAPI.Infrastructure;
using GameAPI.Infrastructure.Extensions;
using GameAPI.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.ConnectionString();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Filtro para exceções personalizadas
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));


//Injeções de dependencia do application e Infrastructure
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


//AddFluentMigrator(builder.Services);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

MigrateDatabase();


app.Run();

void MigrateDatabase()
{
    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    DatabaseMigration.Migrate(connectionString, serviceScope.ServiceProvider);
}
