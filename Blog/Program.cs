using System.Data.Common;
using System.Reflection;
using FluentMigrator.Runner;
using Npgsql;
using WebApplication6.Repositories;
using WebApplication6.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
var connectionString = builder.Configuration.GetConnectionString("ConnectionDataBase");
builder.Services.AddSingleton<DbConnection>(_ =>
    new NpgsqlConnection(connectionString));
builder.Services.AddSingleton<IArticleRepository, ArticleRepository>();
builder.Services
    .AddFluentMigratorCore().ConfigureRunner(rb =>
        rb.AddPostgres()
            .WithGlobalConnectionString(connectionString)
            .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole())
    .BuildServiceProvider(false);

var app = builder.Build();
using var serviceProvider = app.Services.CreateScope();
var services = serviceProvider.ServiceProvider;
var runner = services.GetRequiredService<IMigrationRunner>();
runner.MigrateUp();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();