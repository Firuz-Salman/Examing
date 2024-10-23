namespace Examing.Server.Models.DTO
{
     public class ExamCreateDTO
     {
          public required DateTime Date { get; set; }
          public required Guid StudentId { get; set; }
          public required Guid LessonId { get; set; }
          public required int Grade { get; set; }
     }
}
