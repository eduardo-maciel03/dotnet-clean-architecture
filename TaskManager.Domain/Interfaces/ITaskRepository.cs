using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync(TaskItemStatus? status = null);
    Task AddAsync(TaskItem task);
}
