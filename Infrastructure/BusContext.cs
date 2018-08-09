using Domain.Mementos;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
    public class BusContext: DbContext
    {
        public DbSet<BusMemento> Buses { get; set; }
        public DbSet<BusRouteMemento> BusRoutes { get; set; }


        public BusContext()
        { }

        public BusContext(DbContextOptions<BusContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BusesConfiguration());
        }
    }
}
