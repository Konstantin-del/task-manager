using AutoMapper;
using TaskManager.Application.Dtos;
using TaskManager.Core;
using TaskManager.Persistence;

namespace TaskManager.Application;

public class TaskService(
    ITaskRepository taskRepository,
    IMapper mapper
    ) : ITaskService
{
    public async Task<TaskDto> AddTaskAsync(TaskDto request)
    {
        var taskEntity = mapper.Map<TaskEntity>(request);
        taskEntity.Status = Status.ToDo;
        taskEntity.CreatedTime = DateTimeOffset.Now;
        var task = await taskRepository.AddTaskAsync(taskEntity);
        return mapper.Map<TaskDto>(task);
    }

    public async Task<List<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await taskRepository.GetAllTasksAsync();
        return mapper.Map<List<TaskDto>>(tasks);
    }

    public async Task<TaskDto> UpdateStatusTasksAsync(int id, Status status)
    {
        var task = await taskRepository.UpdateTaskStatusAsync(id, status);

        return mapper.Map<TaskDto>(task);
    }

    public async Task<List<TaskDto>> UpdateIndexTasksAsync(List<TaskDto> tasks)
    {
        var tasksEntity = mapper.Map<List<TaskEntity>>(tasks);

        await taskRepository.UpdateTasksIndexAsync(tasksEntity);

        var updatedTasks = await taskRepository.GetAllTasksAsync();

        return mapper.Map<List<TaskDto>>(updatedTasks);
    }

    public async Task AddAssignedAsync(int id, string name)
    {
        await taskRepository.AddAssignedAsync(id, name);
    }
}
