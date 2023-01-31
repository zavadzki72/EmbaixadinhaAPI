using Embaixadinha.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embaixadinha.Data.Maps
{
    public class PlayerMap : BaseMap<Player>
    {
        public PlayerMap() : base("player") { }

        public override void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.PlayerIp)
                .IsRequired();

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasIndex(x => x.PlayerIp)
                .IsUnique();

            base.Configure(builder);
        }
    }
}
