
using AutoMapper;
using TaskManager.Application.Dtos;
using TaskManger.Presentation.Models;

namespace TaskManger.Presentation.Mappings;

public class ControllerTaskMapperProfile :Profile
{
    public ControllerTaskMapperProfile()
    {
        CreateMap<TaskDto, TaskResponseModel>();
        CreateMap<AddTaskRequestModel, TaskDto>();
        CreateMap <UpdateTasksRequestModel, TaskDto>();
    }
}
