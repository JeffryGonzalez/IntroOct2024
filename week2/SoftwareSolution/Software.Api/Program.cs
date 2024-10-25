using Marten;
using Software.Api.Catalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("catalog") ?? throw new Exception("No Connection String");
builder.Services.AddScoped<BankAccount>();
builder.Services.AddMarten(cfg =>
{
    cfg.Connection(connectionString); // IDocumentSession
}).UseLightweightSessions();
builder.Services.AddScoped<CatalogManager>();


builder.Services.AddCors(b =>
{
    b.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyOrigin();
        pol.AllowAnyMethod();
        pol.AllowAnyHeader(); // consult your local authorities.
    });
});
var app = builder.Build();

app.UseCors();
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


public class BankAccount
{

}