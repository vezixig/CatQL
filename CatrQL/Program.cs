using CatQL.Application;
using CatQL.Core;
using CatQL.Infrastructure;
using CatQL.Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add layers
builder.Services.AddCore();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddPresentation();

// Add services to the container.
//builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
//app.MapControllers();
app.UseGraphQL();

app.Run();