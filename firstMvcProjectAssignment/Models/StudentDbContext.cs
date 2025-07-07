
using System.Data.Entity;

public class StudentDbContext : DbContext
{
    public StudentDbContext() :base("name=StudentDbContext")
    {

    }
    public DbSet<Student> Students { get; set; }
}