using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class BusContextDesignTimeFactory : IDesignTimeDbContextFactory<BusContext>
    {
        public BusContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<BusContext>()
                .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=BusRoutes;Trusted_Connection=True;")
                .Options;

            return new BusContext(options);
        }
    }
}
