
namespace Infrastructure.Data
{
    using Core;
    using Microsoft.EntityFrameworkCore;
    public class SallaryContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
        public SallaryContext(DbContextOptions<SallaryContext> options) : base(options)
        {

        }
    }

}