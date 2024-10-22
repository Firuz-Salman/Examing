namespace Examing.Server.Models.DTO
{
     public class StudentViewModel
     {
          public Guid Id { get; set; } = Guid.NewGuid();
          public int StudentNumber { get; set; }
          public string Name { get; set; }
          public string Surname { get; set; }
          public int Class { get; set; }
     }
}
