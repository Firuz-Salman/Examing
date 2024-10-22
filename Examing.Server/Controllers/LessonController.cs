using Examing.Server.Data;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class LessonController : Controller
     {
          private readonly ApplicationDbContext _context;

        public LessonController(ApplicationDbContext context)
        {
               _context = context;
        }


          [HttpGet]
          public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons()
          {
               return await _context.Lessons.ToListAsync();
          }

          [HttpPost]
          public async Task<ActionResult<Lesson>> CreateExam(LessonCreateDTO lesson)
          {
               var lessonEntity = new Lesson {Code  = lesson.Code, Class = lesson.Class, Name = lesson.Name, TeacherName = lesson.TeacherName, TeacherSurname = lesson.TeacherSurname };
               _context.Lessons.Add(lessonEntity);
               await _context.SaveChangesAsync();

               return CreatedAtAction(nameof(GetLessons), lessonEntity);
          }
     }
}
