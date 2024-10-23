using Examing.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Data
{
     public class ApplicationDbContext : DbContext
     {
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

          public DbSet<Exam> Exams { get; set; }
          public DbSet<Lesson> Lessons { get; set; }
          public DbSet<Student> Students { get; set; }




          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               modelBuilder.Entity<Lesson>(entity =>
               {
                    // LessonCode char(3)
                    entity.Property(e => e.Code)
                        .HasMaxLength(3)
                        .IsFixedLength()
                        .IsRequired();

                    // LessonName varchar(30)
                    entity.Property(e => e.Name)
                          .HasMaxLength(30)
                          .IsRequired();

                    // Class number(2,0)
                    entity.Property(e => e.Class)
                          .HasPrecision(2, 0)
                          .IsRequired();

                    // TeacherName varchar(20)
                    entity.Property(e => e.TeacherName)
                          .HasMaxLength(20)
                          .IsRequired();

                    // TeacherSurname varchar(20)
                    entity.Property(e => e.TeacherSurname)
                          .HasMaxLength(20)
                          .IsRequired();
               });

               modelBuilder.Entity<Student>(entity =>
               {
                    //StudentNumber number(5,0)
                    entity.Property(e => e.StudentNumber)
                          .HasPrecision(5, 0)
                          .IsRequired();

                    //Name varchar(30)
                    entity.Property(e => e.Name)
                          .HasMaxLength(30)
                          .IsRequired();

                    //Surname  varchar(30)
                    entity.Property(e => e.Surname)
                          .HasMaxLength(30)
                          .IsRequired();

                    // Class number(2,0)
                    entity.Property(e => e.Class)
                          .HasPrecision(2, 0)
                          .IsRequired();
               });

               modelBuilder.Entity<Exam>(entity =>
               {
                    //Grade number(5,0)
                    entity.Property(e => e.Grade)
                          .HasPrecision(1, 0)
                          .IsRequired();
               });
          }

     }
}