using Domain.Mementos;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class BusContext: DbContext
    {
        public DbSet<BusMemento> Buses { get; set; }
        public DbSet<BusRouteMemento> BusRoutes { get; set; }
        public DbSet<ScheduledServiceMemento> Services { get; set; }

        public BusContext()
        { }

        public BusContext(DbContextOptions<BusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BusesConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=BusRoutes;Trusted_Connection=True;");
        }
    }
}
