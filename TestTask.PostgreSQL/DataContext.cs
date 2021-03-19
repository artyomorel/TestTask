using TestTask.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestTask.PostgreSQL
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options):base(options)
        { }

        public DbSet<Person> People { get; set; }
        public DbSet<PFR> PFRs { get; set; }
    }
}
