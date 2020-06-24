using Microsoft.EntityFrameworkCore;

namespace SimpleCMS.Persistence
{
    public class SimpleDbContextFactory : DesignTimeDbContextFactoryBase<SimpleDbContext>
    {
        protected override SimpleDbContext CreateNewInstance(DbContextOptions<SimpleDbContext> options)
        {
            return new SimpleDbContext(options);
        }
    }
}
