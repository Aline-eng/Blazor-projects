using TaskManager.Models;

namespace TaskManager.Services
{
    public interface ITaskService
    {
    Task<List<TaskItem>> GetTasksAsync();
    Task<TaskItem?> GetTaskAsync(int id);
    Task AddTaskAsync(TaskItem task);
    Task UpdateTaskAsync(TaskItem task);
    Task DeleteTaskAsync(int id);
}

public class TaskService : ITaskService
{
    private List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public Task<List<TaskItem>> GetTasksAsync() => Task.FromResult(_tasks);

    public Task<TaskItem?> GetTaskAsync(int id) => 
        Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));

    public Task AddTaskAsync(TaskItem task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
        return Task.CompletedTask;
    }

    public Task UpdateTaskAsync(TaskItem task)
    {
        var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existing != null)
        {
            existing.Title = task.Title;
            existing.Description = task.Description;
            existing.IsCompleted = task.IsCompleted;
            existing.Priority = task.Priority;
            existing.DueDate = task.DueDate;
        }
        return Task.CompletedTask;
    }

    public Task DeleteTaskAsync(int id)
    {
        _tasks.RemoveAll(t => t.Id == id);
        return Task.CompletedTask;
    }
}
}