using Examing.Server.Data;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class StudentController : Controller
     {
          private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
               _context = context;
        }


          [HttpGet]
          public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
          {
               return await _context.Students.ToListAsync();
          }

          [HttpPost]
          public async Task<ActionResult<Student>> CreateExam(StudentCreateDTO student)
          {
               var studentEntity = new Student {StudentNumber  = student.StudentNumber, Class = student.Class, Name = student.Name, Surname = student.Surname };
               _context.Students.Add(studentEntity);
               await _context.SaveChangesAsync();

               return CreatedAtAction(nameof(GetStudents), studentEntity);
          }
     }
}
