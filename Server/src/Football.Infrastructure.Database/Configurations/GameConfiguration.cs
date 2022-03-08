using Football.Core.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Football.Infrastructure.Database.Configurations
{
    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.OwnsOne(x => x.GameResult);

            builder.HasMany(x => x.Participations).WithOne(x => x.Game)
                .OnDelete(DeleteBehavior.Cascade)
                .Metadata.PrincipalToDependent?.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(x => x.PlayerNumber, x => {
                x.Property(xx => xx.Value).HasColumnName("PlayerNumber");
            });
        }
    }
}
