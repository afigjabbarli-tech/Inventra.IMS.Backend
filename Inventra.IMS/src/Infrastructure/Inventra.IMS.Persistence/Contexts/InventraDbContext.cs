using Inventra.IMS.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Inventra.IMS.Persistence.Contexts
{
    public class InventraDbContext : DbContext
    {
        public InventraDbContext(DbContextOptions<InventraDbContext> dbContextOptions)
            : base(options: dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyGlobalQueryFilters();
        }
    }
}
