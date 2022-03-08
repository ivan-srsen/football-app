using Football.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.Infrastructure.Database.Configurations
{
    public class RecurringGameConfiguration : IEntityTypeConfiguration<RecurringGame>
    {
        public void Configure(EntityTypeBuilder<RecurringGame> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.PlayerNumber, x => {
                x.Property(xx => xx.Value).HasColumnName("PlayerNumber");
            });

            builder.OwnsOne(x => x.Day, x =>
            {
                x.Property(xx => xx.Value).HasColumnName("Day");
            });
        }
    }
}
