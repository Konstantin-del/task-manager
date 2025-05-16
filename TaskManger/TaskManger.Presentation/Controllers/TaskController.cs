using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application;
using TaskManager.Application.Dtos;
using TaskManager.Core;
using TaskManger.Presentation.Models;

namespace TaskManger.Presentation.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController(
    ITaskService taskService,
    IMapper mapper
    ) : Controller
{
    [HttpPost]
    public async Task<ActionResult<int>> AddTaskAsync([FromBody] AddTaskRequestModel request)
    {
        var task = mapper.Map<TaskDto>(request);
        var id = await taskService.AddTaskAsync(task);
        return Ok(id);
    }

    [HttpGet]
    public async Task<ActionResult<List<TaskResponseModel>>> GetAllTaskAsync()
    {
        var tasks = await taskService.GetAllTasksAsync();
        var tasksList = mapper.Map<List<TaskResponseModel>>(tasks);
        return Ok(tasksList);
    }

    [HttpPatch("status")]
    public async Task<ActionResult<TaskResponseModel>> UpdateStatusTaskAsync(
        [FromQuery] int id, Status status)
    {
        var task = await taskService.UpdateStatusTasksAsync(id, status);
        var updatedTask = mapper.Map<TaskDto>(task);
        return Ok(updatedTask);
    }

    public async Task<ActionResult<List<TaskResponseModel>>> UpdateTaskAsync(
       [FromBody] List<UpdateTasksRequestModel> tasks)
    {
        var tasksList = mapper.Map<List<TaskDto>>(tasks);
        var updatedTasks = await taskService.UpdateIndexTasksAsync(tasksList);
        return Ok(updatedTasks);
    }

    [HttpPatch("Assigned")]
    public async Task<ActionResult> AddAssignedAsync([FromQuery] int id, string name)
    {
        await taskService.AddAssignedAsync(id, name);
        return Ok();
    }
}
