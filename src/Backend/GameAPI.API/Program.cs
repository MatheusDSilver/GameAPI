using GameAPI.API.Filters;
using GameAPI.Application;
using GameAPI.Domain.Repositories;
using GameAPI.Infrastructure;
using GameAPI.Infrastructure.Extensions;
using GameAPI.Infrastructure.Migrations;
using GameAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.ConnectionString();

builder.Services.AddDbContext<GameApiDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<PlayerService>();
builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Filtro para exceções personalizadas
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

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
    DatabaseMigration.Migrate(connectionString);
}
