using AutoMapper;
using ToDoList.DTOs;
using ToDoList.Models;

namespace ToDoList.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            

            // ToDoLists <-> DTOs
            CreateMap<ToDoLists, ToDoListDto>().ReverseMap();
            CreateMap<ToDoLists, CreateToDoListDto>().ReverseMap();

            // TaskLists <-> DTOs
            CreateMap<TaskLists, TaskListDto>().ReverseMap();
            CreateMap<TaskLists, CreateTaskDto>().ReverseMap();
            CreateMap<TaskLists, UpdateTaskDto>().ReverseMap();

            // AssignedTask <-> DTOs
            CreateMap<AssignedTask, AssignedTaskDto>().ReverseMap();
            CreateMap<AssignedTask, AssignTaskDto>().ReverseMap();

            // DeletedTask <-> DTOs
            CreateMap<DeletedTask, DeletedTaskDto>().ReverseMap();
        }
    }
}
