namespace Examing.Server.Models.DTO
{
     public class LessonViewModel
     {
          public Guid Id { get; set; }
          public string Code { get; set; }
          public string Name { get; set; }
          public int Class { get; set; }
          public string TeacherName { get; set; }
          public string TeacherSurname { get; set; }
     }
}
