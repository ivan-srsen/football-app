using Football.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.Infrastructure.Database.Configurations
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Participations).WithOne(y => y.Player)
                .OnDelete(DeleteBehavior.Cascade)
                .Metadata.PrincipalToDependent?.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
