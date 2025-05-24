using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.UseCases.CreateTask;

public class CreateTaskHandler
{
    private readonly ITaskRepository _repository;

    public CreateTaskHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> HandleAsync(CreateTaskRequest request)
    {
        var task = new TaskItem(request.Title, request.Description);
        await _repository.AddAsync(task);
        return task.Id;
    }
}