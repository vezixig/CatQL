using System.Reflection;
using API.GraphQL.Schema;
using GraphQL;
using GraphQL.Types;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddGraphQL(
    b => b.AddSystemTextJson()
        .AddGraphTypes(Assembly.GetCallingAssembly()));

builder.Services.AddScoped<ISchema, CatSchema>();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
app.UseGraphQL();

app.Run();