using AutoMapper;
using Examing.Server.Data;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Services
{
     public class StudentService
     {

          private readonly ApplicationDbContext _context;
          private readonly IMapper _mapper;

          public StudentService(ApplicationDbContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<IEnumerable<StudentViewModel>> GetStudentsAsync()
          {
               var studentEntities = await _context.Students.ToListAsync();
               var studentDTOs = _mapper.Map<IEnumerable<Student>, List<StudentViewModel>>(studentEntities);

               return studentDTOs;
          }



          public async Task<StudentViewModel> CreateStudentAsync(StudentCreateDTO studentDto)
          {
               var studentEntity = _mapper.Map<StudentCreateDTO, Student>(studentDto);
               _context.Students.Add(studentEntity);
               await _context.SaveChangesAsync();

               return _mapper.Map<Student, StudentViewModel>(studentEntity);
          }

     }
}
