using TaskManager.Application.UseCases.CreateTask;
using TaskManager.Application.UseCases.GetTasks;
using TaskManager.Domain.Interfaces;
using TaskManager.Infrastructure.Repositories;
using TaskManager.WebAPI.Endpoints;
using TaskManager.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositories
builder.Services.AddScoped<ITaskRepository, InMemoryTaskRepository>();

// Use Cases
builder.Services.AddScoped<CreateTaskHandler>();
builder.Services.AddScoped<GetTasksHandler>();

// Authentication
builder.Services.AddCookieAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Endpoints
app.MapAuthenticationEndpoints();
app.MapTaskEndpoints();

app.Run();