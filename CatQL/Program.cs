using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
var connectionString = "server=localhost;user=root;password=;database=catql";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());


var app = builder.Build();


app.UseHttpsRedirection();
app.MapControllers();

app.Run();