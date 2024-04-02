using Microsoft.Extensions.Configuration;
using ConstructionFlow.IoC;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// remove cors security
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowLocalhost",
               builder =>
               {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDatabaseConfig(configuration);
builder.Services.AddUnitOfWork(configuration);
builder.Services.AddAutomapper(configuration);
builder.Services.AddBusinesses(configuration);
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("AllowLocalhost");
app.MapControllers();
app.Run();
