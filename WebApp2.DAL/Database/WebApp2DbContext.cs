
using WebApp2.DAL.Entity;

namespace WebApp2.DAL.Database
{
    public class WebApp2DbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
        public WebApp2DbContext(DbContextOptions<WebApp2DbContext> options) : base(options)
        {
        }

    }
}
