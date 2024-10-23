using Examing.Server.Data;
using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Examing.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class StudentController : Controller
     {
          private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
               _studentService = studentService;
        }


          [HttpGet]
          public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
          {
               return Ok(await _studentService.GetStudentsAsync());
          }

          [HttpPost]
          public async Task<ActionResult<Student>> CreateExam(StudentCreateDTO student)
          {    
               return CreatedAtAction(nameof(GetStudents), await _studentService.CreateStudentAsync(student));
          }
     }
}
