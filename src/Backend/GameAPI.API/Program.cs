using FluentMigrator.Runner;
using GameAPI.API.Filters;
using GameAPI.Application;
using GameAPI.Domain.Repositories;
using GameAPI.Infrastructure;
using GameAPI.Infrastructure.Extensions;
using GameAPI.Infrastructure.Migrations;
using GameAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.ConnectionString();

builder.Services.AddDbContext<GameApiDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


//builder.Services.AddScoped<RegisterPlayerUseCase>();

builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Filtro para exceções personalizadas
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));


//Injeções de dependencia do application
builder.Services.AddApplication();

AddFluentMigrator(builder.Services);

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

//AddFluentMigrator(builder.Services);

MigrateDatabase();



app.Run();


void AddFluentMigrator(IServiceCollection services)
{
    services.AddFluentMigratorCore().ConfigureRunner(options =>
    {
        options
        .AddMySql5()
        .WithGlobalConnectionString(connectionString)
        .ScanIn(Assembly.Load("GameAPI.Infrastructure")).For.All();
    });
}

void MigrateDatabase()
{
    var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    DatabaseMigration.Migrate(connectionString, serviceScope.ServiceProvider);
}
