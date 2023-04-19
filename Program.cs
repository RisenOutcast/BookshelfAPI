// Core file of the program, the start and the end.
// Author: Metso (@RisenOutcast)

using BookshelfAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BooksContext>(options =>
   options.UseSqlite(builder.Configuration.GetConnectionString("BooksDB")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Swagger is used for easy testing in debugging
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Disabled Https for easier sharing,
// Enable if using this project for an actual api
// Enabling requires to also add second url, see "launchSettings.json"
// Enabling also requires uncommenting part of "appsettings.json"
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
