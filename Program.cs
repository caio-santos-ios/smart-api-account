using api_account.module.Services;
using api_account.module.Interfaces;
using api_account.module.Repositories;
using MongoDB.Driver;
using MediatR;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Configuração do MongoDB
var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings");
var mongoClient = new MongoClient(mongoDBSettings["ConnectionString"]);
var database  = mongoClient.GetDatabase(mongoDBSettings["DatabaseName"]);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<MongoDbService>();
builder.Services.AddControllers();

// Registro do MongoDB
builder.Services.AddSingleton<IMongoDatabase>(database);

// Registro dos Services e Repositories
builder.Services.AddSingleton<IAccountRepository, AccountRepository>();
builder.Services.AddSingleton<IAccountService, AccountService>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "suaIssuer",
        ValidAudience = "seuAudience",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("suaChaveSecretaCom128Bits"))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStatusCodePages(async statusCodeContext =>
{
    // using static System.Net.Mime.MediaTypeNames;
    statusCodeContext.HttpContext.Response.ContentType = Text.Plain;

    await statusCodeContext.HttpContext.Response.WriteAsync(
        $"Status Code Page: {statusCodeContext.HttpContext.Response.StatusCode}");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
app.Run();