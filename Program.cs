
using API.Data;
using API.Middleware;
using API.Repositories;
using API.Services;
using DotNetEnv;
using Microsoft.EntityFrameworkCore;

Env.Load();
var conn = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(conn));
builder.Services.AddScoped<IIssueRepository, IssueRepository>();
builder.Services.AddScoped<IssueService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
