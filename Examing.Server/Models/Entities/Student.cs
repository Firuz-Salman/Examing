namespace Examing.Server.Models.Entities
{
     public class Student
     {
          public Guid Id { get; set; } = Guid.NewGuid();
          public int StudentNumber { get; set; }
          public string Name { get; set; }
          public string Surname { get; set; }
          public int Class { get; set; }
          public DateTime CreatedDate { get; set; } = DateTime.Now;
          public bool Deletted { get; set; } = false;

     }
}
