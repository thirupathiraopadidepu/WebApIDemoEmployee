using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using WebApIDemoEmployee.Moidel;

namespace WebApIDemoEmployee.Migrations
{
    public class EmpDbContext : DbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) :
            base(options)
        {

        }
        public DbSet<Employee>? Employees { get; set; }

    }
}
