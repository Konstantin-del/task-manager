using Microsoft.EntityFrameworkCore;
using TaskManager.Core;

namespace TaskManager.Persistence;

public class TaskRepository(TaskContext context): ITaskRepository
{
    public async Task<TaskEntity> AddTaskAsync(TaskEntity request)
    {
        var result = await context.Tasks.AddAsync(request);
        await context.SaveChangesAsync();
        return result.Entity;
    }
    public async Task<List<TaskEntity>> GetAllTasksAsync()
    {
        return await context.Tasks.ToListAsync();
    }

    public async Task UpdateTasksIndexAsync(List<TaskEntity> tasks)
    {
        await context.Tasks.ForEachAsync(task =>
        {
            var item = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (item is not null)
            {
                task.Index = item.Index;
            }    
        });
        await context.SaveChangesAsync();    
    }

    public async Task<TaskEntity?> UpdateTaskStatusAsync(int id, Status status)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if(task is not null) 
        {
            task.Status = status;
            await context.SaveChangesAsync();
            return task;
        }
        return null;
    }

    public async Task AddAssignedAsync(int id, string name)
    {
        var task = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if(task is not null) 
        {
            task.AssignedTo = name;
            await context.SaveChangesAsync();
        }   
    }
}
