using CatQL.Application;
using CatQL.Core;
using CatQL.Health;
using CatQL.Infrastructure;
using CatQL.Presentation;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add layers
builder.Services.AddCore();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPresentation();

// Add diagnostic
builder.Services.AddHealthChecks()
    .AddCheck<DataContextHealthCheck>("DataBase");

// Add services to the container.
//builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
//app.MapControllers();
app.UseGraphQL();
app.MapHealthChecks("_health", new() { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });

app.Run();