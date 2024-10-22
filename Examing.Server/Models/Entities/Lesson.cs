namespace Examing.Server.Models.Entities
{
     public class Lesson
     {
          public Guid Id { get; set; } = Guid.NewGuid();
          public string Code { get; set; }
          public string Name { get; set; }
          public int Class { get; set; }
          public string TeacherName { get; set; }
          public string TeacherSurname { get; set; }
          public DateTime CreatedDate { get; set; } = DateTime.Now;
          public bool Deletted { get; set; } = false;

     }
}
