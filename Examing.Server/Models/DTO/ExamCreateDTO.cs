namespace Examing.Server.Models.DTO
{
     public class ExamCreateDTO
     {
          public DateTime Date { get; set; }
          public Guid StudentId { get; set; }
          public Guid LessonId { get; set; }
          public int Grade { get; set; }
     }
}
