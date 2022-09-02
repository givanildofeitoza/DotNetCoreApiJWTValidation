using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Data;
using Business;
using Data.Context;
using Api.Config;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigDependency();
builder.Services.ConfigIdentity(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var ConnectionString = builder.Configuration.GetConnectionString("MySqlString");
builder.Services.AddDbContext<appDbContext>(options =>
options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString)));



var app = builder.Build();

app.UseAuthentication();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
