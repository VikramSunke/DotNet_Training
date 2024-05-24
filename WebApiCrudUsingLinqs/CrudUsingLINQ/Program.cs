
using CrudUsingLINQ.Data;
using CrudUsingLINQ.Interfaces;
using CrudUsingLINQ.Services;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();

            builder.Services.AddDbContext<EmployeeDBContext>(opt => opt.UseSqlServer(
                             builder.Configuration.GetConnectionString("conStr")));

            builder.Services.AddScoped<IEmployee, EmployeeService>();
            builder.Services.AddScoped<IDepartment, DepartmentService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
