
using AutoMapper;
using TaskManager.Application.Dtos;
using TaskManager.Persistence;

namespace TaskManager.Application.Mapping
{
    public class TaskMapperProfile : Profile
    {
        public TaskMapperProfile()
        {
            CreateMap<TaskEntity, TaskDto>().ReverseMap();
        }
    }
}
