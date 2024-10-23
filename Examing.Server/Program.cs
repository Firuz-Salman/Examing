
using Examing.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Examing.Server
{
     public class Program
     {
          public static void Main(string[] args)
          {
               var builder = WebApplication.CreateBuilder(args);

               // Add services to the container.

               builder.Services.AddControllers();
               // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
               builder.Services.AddEndpointsApiExplorer();
               builder.Services.AddSwaggerGen();
               var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
               builder.Services.AddDbContext<ApplicationDbContext>(options =>
                                  options.UseSqlServer(connectionString));

               //           builder.Services.AddDbContext<ApplicationDbContext>(options =>
               //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

