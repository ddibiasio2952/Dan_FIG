using FalveyInsuranceGroup.db;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Configuration;

// Used https://www.youtube.com/watch?v=38GNKtclDdE as an overall guide.
// Used https://www.youtube.com/watch?v=nFwe5mWa6TY for Http Patch method
// Used ChatGPT to diagnose connectivity issues to MySQL

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. AddNewtonsoftJson is for the Patch method.
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
throw new InvalidOperationException("Connection failed.");
}

builder.Services.AddDbContext<FalveyInsuranceGroupContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
