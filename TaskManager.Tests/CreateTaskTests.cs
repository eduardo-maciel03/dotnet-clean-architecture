using TaskManager.Application.DTOs;
using TaskManager.Application.UseCases.CreateTask;
using TaskManager.Infrastructure.Repositories;
using FluentAssertions;

namespace TaskManager.Tests;

public class CreateTaskTests
{
    [Fact]
    public async Task Should_Create_Task_With_Valid_Data()
    {
        var repository = new InMemoryTaskRepository();
        var handler = new CreateTaskHandler(repository);

        var request = new CreateTaskRequest
        {
            Title = "Test Task",
            Description = "This is a test"
        };

        var id = await handler.HandleAsync(request);

        id.Should().NotBeEmpty();
    }
}
