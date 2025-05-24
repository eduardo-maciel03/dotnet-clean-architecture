namespace TaskManager.Domain.Entities;

public class TaskItem(string title, string? description = null)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; } = title ?? throw new ArgumentNullException(nameof(title));
    public string? Description { get; private set; } = description;
    public TaskItemStatus Status { get; private set; } = TaskItemStatus.Pending;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public void MarkInProgress() => Status = TaskItemStatus.InProgress;
    public void MarkCompleted() => Status = TaskItemStatus.Completed;
}
