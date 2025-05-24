using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.DTOs;
using TaskManager.Application.UseCases.CreateTask;
using TaskManager.Application.UseCases.GetTasks;
using TaskManager.Domain.Entities;

namespace TaskManager.WebAPI.Endpoints;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/tasks")
            .WithTags("Task Manager")
            .RequireAuthorization(policy =>
                policy.RequireAuthenticatedUser()
            )
            .WithOpenApi();

        group.MapGet("", GetAsync)
             .WithSummary("List tasks")
             .Produces<IEnumerable<TaskItem>>(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status401Unauthorized);

        group.MapPost("", PostAsync)
             .WithSummary("Create a task")
             .Produces(StatusCodes.Status201Created)
             .Produces(StatusCodes.Status401Unauthorized);
    }

    static async Task<IResult> GetAsync(
        [FromQuery] TaskItemStatus? status, GetTasksHandler handler)
    {
        var tasks = await handler.HandleAsync(status);
        return TypedResults.Ok(tasks);
    }

    static async Task<IResult> PostAsync(
        [FromBody] CreateTaskRequest request, CreateTaskHandler handler)
    {
        var id = await handler.HandleAsync(request);
        return TypedResults.Created($"/api/tasks/{id}", new { id });
    }
}
