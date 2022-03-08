using Football.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.Infrastructure.Database.Configurations
{
    internal class ParticipationConfiguration : IEntityTypeConfiguration<Participation>
    {
        public void Configure(EntityTypeBuilder<Participation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Game).WithMany(y => y.Participations);
            builder.HasOne(x => x.Player).WithMany(y => y.Participations);
        }
    }
}
