using GameAPI.API.Filters;
using GameAPI.Application;
using GameAPI.Infrastructure;
using GameAPI.Infrastructure.Extensions;
using GameAPI.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;

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


// --- ADICIONE ESTE BLOCO ---
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Pega o seu Contexto do Banco de Dados (Troque pelo nome correto da sua classe DbContext)
        var context = services.GetRequiredService<GameAPI.Infrastructure.GameApiDbContext>();

        // Esta linha faz a mágica: aplica todas as migrations pendentes e cria o banco se não existir
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocorreu um erro ao rodar as Migrations.");
    }
}
// ---------------------------

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
