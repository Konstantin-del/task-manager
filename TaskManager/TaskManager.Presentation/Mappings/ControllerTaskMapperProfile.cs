
using AutoMapper;
using TaskManager.Application.Dtos;
using TaskManager.Presentation.Models;

namespace TaskManager.Presentation.Mappings;

public class ControllerTaskMapperProfile :Profile
{
    public ControllerTaskMapperProfile()
    {
        CreateMap<TaskDto, TaskResponseModel>();
        CreateMap<AddTaskRequestModel, TaskDto>();
        CreateMap <UpdateTasksRequestModel, TaskDto>();
    }
}
