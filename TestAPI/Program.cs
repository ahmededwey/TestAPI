

using CQRS_lib;
using CQRS_lib.DATA.Models;
using CQRS_lib.REPO.Departments;
using CQRS_lib.REPO.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TestAPI.Controllers;


namespace TestAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Log.Logger = new LoggerConfiguration()
                 .MinimumLevel.Information()
                 .WriteTo.Console()
                 .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                 .CreateLogger();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocal5500", policy =>
                {
                    policy
                        .WithOrigins("http://127.0.0.1:5500") 
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                   
                });
            });

            builder.Host.UseSerilog();
            // Add services to the container.

            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();


            builder.Services.AddMediatR(typeof(MyLib).Assembly);
           







            builder.Services.AddControllers();
            //builder.Services.AddControllers()
            //    .AddNewtonsoftJson(op=>op.SerializerSettings.ReferenceLoopHandling=Newtonsoft.
            //    Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseLazyLoadingProxies().UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                    ));

            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           


            var app = builder.Build();
            app.UseCors("AllowLocal5500");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

             if (app.Environment.IsDevelopment())
             {
                 app.UseSwagger();
                 app.UseSwaggerUI();
             };
                  
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

                    

            app.Run();
        }
    }
}
