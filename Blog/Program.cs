using System.Reflection;
using FluentMigrator.Runner;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("ConnectionDataBase");
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

app.UseSwagger();
app.UseSwaggerUI();
app.Run();