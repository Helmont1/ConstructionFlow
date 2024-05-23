using Microsoft.Extensions.Configuration;
using ConstructionFlow.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var origins = new string[] { "http://localhost:4200", "https://constructionflow.netlify.app" };

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowLocalhost",
               builder =>
               {
            builder.WithOrigins(origins)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddDatabaseConfig(configuration);
builder.Services.AddUnitOfWork(configuration);
builder.Services.AddAutomapper(configuration);
builder.Services.AddBusinesses(configuration);
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseAuthorization();
app.UseCors("AllowLocalhost");
app.MapControllers();
app.UseAuthentication();
app.Run();
