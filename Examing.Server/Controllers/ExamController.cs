using Examing.Server.Data;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class ExamController : ControllerBase
     {
          private readonly ApplicationDbContext _context;

          public ExamController(ApplicationDbContext context)
          {
               _context = context;
          }

          [HttpGet]
          public async Task<ActionResult<IEnumerable<Exam>>> GetExams()
          {
               return await _context.Exams.Include(x => x.Lesson).Include(X=>X.Student).ToListAsync();
          }

          [HttpPost]
          public async Task<ActionResult<Exam>> CreateExam(ExamCreateDTO exam)
          {
               var examEntity = new Exam { Date = exam.Date, Grade = exam.Grade, LessonId = exam.LessonId, StudentId = exam.StudentId }; 
               _context.Exams.Add(examEntity);
               await _context.SaveChangesAsync();
                             
               return CreatedAtAction(nameof(GetExams), examEntity);
          }
     }

}
