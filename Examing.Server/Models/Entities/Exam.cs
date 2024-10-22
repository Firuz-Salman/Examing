namespace Examing.Server.Models.Entities
{
     public class Exam
     {
          public Guid Id { get; set; } = Guid.NewGuid();
          public DateTime Date { get; set; }
          public Guid StudentId { get; set; }
          public Guid LessonId { get; set; }
          public int Grade { get; set; }
          public DateTime CreatedDate { get; set; } = DateTime.Now;
          public bool Deletted { get; set; } = false;


          public Student Student { get; set; }
          public Lesson Lesson { get; set; }
     }
}
