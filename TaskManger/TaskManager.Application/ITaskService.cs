using TaskManager.Application.Dtos;
using TaskManager.Core;

namespace TaskManager.Application;

public interface ITaskService
{
    public Task<TaskDto> AddTaskAsync(TaskDto task);

    public Task<List<TaskDto>> GetAllTasksAsync();

    public Task<TaskDto> UpdateStatusTasksAsync(int id, Status status);

    public Task<List<TaskDto>> UpdateIndexTasksAsync(List<TaskDto> tasks);
}
