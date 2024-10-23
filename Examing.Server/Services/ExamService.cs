using AutoMapper;
using Examing.Server.Data;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Services
{
     public class ExamService
     {
          private readonly ApplicationDbContext _context;
          private readonly IMapper _mapper;

          public ExamService(ApplicationDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<IEnumerable<ExamViewModel>> GetExamsAsync()
          {
               var examEntities = await _context.Exams.Include(x => x.Lesson).Include(X => X.Student).ToListAsync();
               var examDTOs = _mapper.Map<IEnumerable<Exam>, List<ExamViewModel>>(examEntities);

               return examDTOs;
          }



          public async Task<ExamViewModel> CreateExamAsync(ExamCreateDTO examDto)
          {
               var examEntity = _mapper.Map<ExamCreateDTO, Exam>(examDto);
               _context.Exams.Add(examEntity);
               await _context.SaveChangesAsync();

               examEntity = await _context.Exams.Include(x => x.Lesson).Include(x => x.Student).FirstOrDefaultAsync(x => x.Id == examEntity.Id);

               return _mapper.Map<Exam, ExamViewModel>(examEntity);
          }
     }
}
