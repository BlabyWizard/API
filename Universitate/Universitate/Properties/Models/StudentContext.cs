using Microsoft.EntityFrameworkCore;

namespace Universitate.Properties.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            :base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> students { get; set; }
    }
}
