using PrimaryDbSqlServer;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddPrimaryDbSqlServerServices(configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();