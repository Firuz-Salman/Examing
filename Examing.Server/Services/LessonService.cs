using AutoMapper;
using Examing.Server.Data;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Services
{
     public class LessonService
     {

          private readonly ApplicationDbContext _context;
          private readonly IMapper _mapper;

          public LessonService(ApplicationDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<IEnumerable<LessonViewModel>> GetLessonsAsync()
          {
               var lessonEntities = await _context.Lessons.ToListAsync();
               var lessonDTOs = _mapper.Map<List<Lesson>, List<LessonViewModel>>(lessonEntities);

               return lessonDTOs;
          }



          public async Task<LessonViewModel> CreateLessonAsync(LessonCreateDTO lessonDto)
          {
               var lessonEntity = _mapper.Map<LessonCreateDTO, Lesson>(lessonDto);
               _context.Lessons.Add(lessonEntity);
               await _context.SaveChangesAsync();

               return _mapper.Map<Lesson, LessonViewModel>(lessonEntity);
          }
     }
}
