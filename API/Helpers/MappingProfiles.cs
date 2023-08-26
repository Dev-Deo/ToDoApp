using AutoMapper;
using Domain.Entities;
using Domain.Entities.Identity;
using Shared.DTO;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<ApplicationUser, ApplicationUserUpdateDto>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d=> d.ContactNo, o => o.MapFrom(s=> s.ContactNo));

            CreateMap<ApplicationUserDto, ApplicationUser>().ReverseMap();

            CreateMap<ToDoTaskCreateDto, ToDoTask>();
            CreateMap<ToDoTaskCreateDto, ToDoTaskDto>();
            CreateMap<ToDoTaskUpdateDto, ToDoTaskDto>();
            CreateMap<ToDoTask, ToDoTaskDto>().ReverseMap();

            CreateMap<ToDoCreateDto, ToDo>();
            CreateMap<ToDoCreateDto, ToDoDto>();
            CreateMap<ToDoUpdateDto, ToDoDto>();
            CreateMap<ToDo, ToDoDto>().ReverseMap();


        }
    }
}
