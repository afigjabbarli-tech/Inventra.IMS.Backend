using Inventra.IMS.Domain.Entities;
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

        public DbSet<Country> Countries { get; set; }
        public DbSet<FileMetadata> Files { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyGlobalQueryFilters();
        }
    }
}
