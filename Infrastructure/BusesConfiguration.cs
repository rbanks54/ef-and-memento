using Domain.Mementos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure
{
    internal class BusesConfiguration : IEntityTypeConfiguration<BusMemento>
    {
        public void Configure(EntityTypeBuilder<BusMemento> builder)
        {
            builder.HasKey(b => b.Id);
        }
    }
}