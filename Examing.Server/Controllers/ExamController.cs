using Examing.Server.Models.DTO;
using Examing.Server.Models.Entities;
using Examing.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Examing.Server.Controllers
{
     [ApiController]
     [Route("api/[controller]")]
     public class ExamController : ControllerBase
     {
          private readonly ExamService _examService;

          public ExamController(ExamService examService)
          {
               _examService = examService;
          }

          [HttpGet]
          public async Task<ActionResult<IEnumerable<ExamViewModel>>> GetExams()
          {
               return Ok(await _examService.GetExamsAsync());
          }

          [HttpPost]
          public async Task<ActionResult<Exam>> CreateExam(ExamCreateDTO exam)
          {
               var examEntity = await _examService.CreateExamAsync(exam);
                             
               return CreatedAtAction(nameof(GetExams), examEntity);
          }
     }

}
