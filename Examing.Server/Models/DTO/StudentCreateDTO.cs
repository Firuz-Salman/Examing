namespace Examing.Server.Models.DTO
{
     public class StudentCreateDTO
     {
          public required int StudentNumber { get; set; }
          public required string Name { get; set; }
          public required string Surname { get; set; }
          public required int Class { get; set; }
     }
}
