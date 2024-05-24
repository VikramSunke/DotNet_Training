using CrudUsingLINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingLINQ.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> contextOptions) : base(contextOptions)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
