using CrudUsingAsyncAwait.Modals;
using Microsoft.EntityFrameworkCore;

namespace CrudUsingAsyncAwait.Data
{
    public class StudentDbContext :DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}



