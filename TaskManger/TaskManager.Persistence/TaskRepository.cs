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
        var result = await context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if(result is not null) 
        {
            result.Status = status;
            await context.SaveChangesAsync();
            return result;
        }
        return null;
    }


}
