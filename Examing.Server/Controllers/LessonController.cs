using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Examing.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examing.Server.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class LessonController : Controller
     {
          private readonly LessonService _lessonService;

          public LessonController(LessonService lessonService)
          {
               _lessonService = lessonService;
          }


          [HttpGet]
          public async Task<ActionResult<IEnumerable<Lesson>>> GetLessons()
          {
               return Ok(await _lessonService.GetLessonsAsync());
          }

          [HttpPost]
          public async Task<ActionResult<Lesson>> CreateExam(LessonCreateDTO lesson)
          {               
               return CreatedAtAction(nameof(GetLessons), await _lessonService.CreateLessonAsync(lesson));
          }
     }
}
