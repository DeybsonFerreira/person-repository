using Microsoft.EntityFrameworkCore;

namespace app.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}