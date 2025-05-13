
using TaskManager.Core;

namespace TaskManager.Persistence;

public interface ITaskRepository
{
    public Task<TaskEntity> AddTaskAsync(TaskEntity request);

    public Task<List<TaskEntity>> GetAllTasksAsync();

    public Task UpdateTasksIndexAsync(List<TaskEntity> tasks);

    public Task<TaskEntity?>UpdateTaskStatusAsync(int id, Status status);
}
