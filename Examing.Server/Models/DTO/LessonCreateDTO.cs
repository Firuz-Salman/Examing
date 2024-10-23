namespace Examing.Server.Models.DTO
{
     public class LessonCreateDTO
     {
          public required string Code { get; set; }
          public required string Name { get; set; }
          public required int Class { get; set; }
          public required string TeacherName { get; set; }
          public required string TeacherSurname { get; set; }
     }
}
