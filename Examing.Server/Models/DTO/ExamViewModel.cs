using Examing.Server.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Examing.Server.Models.DTO
{
     public class ExamViewModel
     {
          
          public DateTime Date { get; set; }          
          public Student Student { get; set; }
          public Lesson Lesson { get; set; }
          public int Grade { get; set; }
     }
}
