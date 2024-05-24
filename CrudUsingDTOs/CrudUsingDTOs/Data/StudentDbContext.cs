using CrudUsingDTOs.Modals;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingDTOs.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> contextOptions) : base(contextOptions)
        {
            
        }

        public DbSet<Student> Students { get; set; }

    }
}
