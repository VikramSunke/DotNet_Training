using Microsoft.EntityFrameworkCore;
using TokenGeneration.Modals;

namespace TokenGeneration.Data
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> contextOptions) : base(contextOptions)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
