using BugTracker.Models;
using BugTracker.Repositories;
using Microsoft.EntityFrameworkCore;
using static Microsoft.Extensions.DependencyInjection.IServiceCollection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddDbContext<TicketContext>(o => o.UseSqlite("Data source=tickets.db"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
