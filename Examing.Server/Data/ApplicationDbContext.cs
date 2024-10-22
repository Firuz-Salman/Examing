using Examing.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server.Data
{
     public class ApplicationDbContext : DbContext
     {
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

          // Определи DbSet для каждой сущности
          public DbSet<Exam> Exams { get; set; }
          public DbSet<Lesson> Lessons { get; set; }
          public DbSet<Student> Students { get; set; }




          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
               modelBuilder.Entity<Lesson>(entity =>
               {
                    // LessonCode üçün char(3) constraint
                    entity.Property(e => e.Code)
                        .HasMaxLength(3) // char(3) kimi istifadə olunur
                        .IsFixedLength() // Bu, 'char' tipini təmsil edir (sabit uzunluq).
                        .IsRequired();   // NULL ola bilməz

                    // LessonName üçün varchar(30) constraint
                    entity.Property(e => e.Name)
                          .HasMaxLength(30) // varchar(30)
                          .IsRequired();    // NULL ola bilməz

                    // Class üçün number(2,0) constraint
                    entity.Property(e => e.Class)
                          .HasPrecision(2, 0) // number(2,0) kimi dəqiqliyi təyin edir
                          .IsRequired();      // NULL ola bilməz

                    // TeacherName üçün varchar(20) constraint
                    entity.Property(e => e.TeacherName)
                          .HasMaxLength(20) // varchar(20)
                          .IsRequired();    // NULL ola bilməz

                    // TeacherSurname üçün varchar(20) constraint
                    entity.Property(e => e.TeacherSurname)
                          .HasMaxLength(20) // varchar(20)
                          .IsRequired();    // NULL ola bilməz
               });

               modelBuilder.Entity<Student>(entity =>
               {
                    
                    entity.Property(e => e.StudentNumber)
                          .HasPrecision(5, 0) // number(5,0) kimi dəqiqliyi təyin edir
                          .IsRequired();      // NULL ola bilməz

                    entity.Property(e => e.Name)
                          .HasMaxLength(30) // varchar(30)
                          .IsRequired();    // NULL ola bilməz
                    
                    
                    entity.Property(e => e.Surname)
                          .HasMaxLength(30) // varchar(30)
                          .IsRequired();    // NULL ola bilməz

                    // Class üçün number(2,0) constraint
                    entity.Property(e => e.Class)
                          .HasPrecision(2, 0) // number(2,0) kimi dəqiqliyi təyin edir
                          .IsRequired();      // NULL ola bilməz
               });

               modelBuilder.Entity<Exam>(entity =>
               {

                    entity.Property(e => e.Grade)
                          .HasPrecision(1, 0) // number(5,0) kimi dəqiqliyi təyin edir
                          .IsRequired();      // NULL ola bilməz
               });
          }

     }
}