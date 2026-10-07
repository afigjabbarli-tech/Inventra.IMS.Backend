using Microsoft.EntityFrameworkCore;

namespace Inventra.IMS.Persistence.Contexts
{
    public class InventraDbContext : DbContext
    {
        public InventraDbContext(DbContextOptions<InventraDbContext> dbContextOptions)
            : base(options : dbContextOptions)
        {
            
        }
    }
}
