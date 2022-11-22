using Microsoft.EntityFrameworkCore;

namespace WebCVInfo.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
           : base(options)
        {
        }

        public DbSet<Intern> Interns { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
