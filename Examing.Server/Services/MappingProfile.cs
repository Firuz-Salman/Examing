using AutoMapper;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;

namespace Examing.Server.Services
{
     public class MappingProfile : Profile
     {
          public MappingProfile()
          {
               CreateMap<ExamCreateDTO, Exam>().ReverseMap();

               CreateMap<ExamViewModel, Exam>()
                    .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                    .ForMember(dest => dest.Lesson, opt => opt.MapFrom(src => src.Lesson))
                    .ReverseMap();
               
               CreateMap<LessonCreateDTO, Lesson>().ReverseMap();
               CreateMap<LessonViewModel, Lesson>().ReverseMap();

               CreateMap<StudentCreateDTO, Student>().ReverseMap();
               CreateMap<StudentViewModel, Student>().ReverseMap();
          }
     }
}
