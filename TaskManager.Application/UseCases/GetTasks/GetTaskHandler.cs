using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.UseCases.GetTasks;

public class GetTasksHandler
{
    private readonly ITaskRepository _repository;

    public GetTasksHandler(ITaskRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<TaskItem>> HandleAsync(TaskItemStatus? status = null)
    {
        return _repository.GetAllAsync(status);
    }
}
