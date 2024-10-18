using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("catalog") ?? throw new Exception("No Connection String");

builder.Services.AddMarten(cfg =>
{
    cfg.Connection(connectionString);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // makes that page at /swagger/index.html
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
// we need a way to say "POST /catalog", run this code.

app.Run(); // Blocks here - it just sits and listens for HTTP requests.

// I will not explain this now. no matter how much you beg me. I will later.

public partial class Program; // hey dotnet, when you compile, make it public.
