using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using werehouse_api.Auth;
using werehouse_api.Data;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<TokenProvider>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy("WerehouseApp", policy =>
    {
        policy.WithOrigins(
            "http://localhost:8081", "https://localhost:8081",
            "http://localhost:8082", "https://localhost:8082",
            "http://localhost:8083", "https://localhost:8083",
            "http://localhost:8084", "https://localhost:8084",
            "http://localhost:8085", "https://localhost:8085",
            "http://localhost:8086", "https://localhost:8086",
            "http://localhost:8087", "https://localhost:8087",
            "http://localhost:8088", "https://localhost:8088",
            "http://localhost:8089", "https://localhost:8089")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configurations.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurations["Jwt:Secret"]!)),
        ValidIssuer = configurations["Jwt:Issuer"],
        ValidAudience = configurations["Jwt:Audience"],
        ClockSkew = TimeSpan.FromSeconds(300),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();

    app.UseSwagger();

    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors("WerehouseApp");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
