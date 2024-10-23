
using Examing.Server.Data;
using Examing.Server.Services;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server
{
     public class Program
     {
          public static void Main(string[] args)
          {
               var builder = WebApplication.CreateBuilder(args);

               builder.Services.AddControllers();
               builder.Services.AddEndpointsApiExplorer();
               builder.Services.AddSwaggerGen();
               var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
               builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

               builder.Services.AddAutoMapper(typeof(MappingProfile));

               builder.Services.AddCors(options =>
               {
                    options.AddPolicy("AllowSpecificOrigin",
                        policy =>
                        {
                             policy.WithOrigins("*") 
                   .AllowAnyHeader()
                   .AllowAnyMethod();
                        });
               });

               builder.Services.AddScoped(typeof(ExamService));
               builder.Services.AddScoped(typeof(LessonService));
               builder.Services.AddScoped(typeof(StudentService));

               var app = builder.Build();

               app.UseDefaultFiles();
               app.UseStaticFiles();

               app.UseCors("AllowSpecificOrigin");

               // Configure the HTTP request pipeline.
               if (app.Environment.IsDevelopment())
               {
                    app.UseSwagger();
                    app.UseSwaggerUI();
               }

               app.UseAuthorization();


               app.MapControllers();

               app.MapFallbackToFile("/index.html");

               app.Run();
          }
     }
}

