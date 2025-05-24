using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Infrastructure.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = [];

    public Task<IEnumerable<TaskItem>> GetAllAsync(TaskItemStatus? status = null)
    {
        var result = status is null
            ? _tasks
            : _tasks.Where(t => t.Status == status.Value);

        return Task.FromResult(result.AsEnumerable());
    }

    public Task AddAsync(TaskItem task)
    {
        _tasks.Add(task);
        return Task.CompletedTask;
    }
}
