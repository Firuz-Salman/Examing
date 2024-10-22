using Examing.Server.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Examing.Server.Models.DTO
{
     public class ExamViewModel
     {
          
          public DateTime Date { get; set; }          
          public required Lesson Student { get; set; }
          public required Student Lesson { get; set; }
          public int Grade { get; set; }
     }
}
