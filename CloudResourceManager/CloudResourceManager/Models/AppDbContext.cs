using CloudResourceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudResourcesManager.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<VirtualMachine> VirtualMachines { get; set; }
        public DbSet<ManagedDatabase> ManagedDatabases { get; set; }
    }
}
