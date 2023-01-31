using Embaixadinha.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embaixadinha.Data.Maps
{
    public class ScoreMap : BaseMap<Score>
    {
        public ScoreMap() : base("score") { }

        public override void Configure(EntityTypeBuilder<Score> builder)
        {
            builder.Property(x => x.Value)
                .IsRequired();

            builder.Property(x => x.PlayerId)
                .IsRequired();

            builder.HasOne(x => x.Player)
                .WithMany(x => x.Scores)
                .HasForeignKey(x => x.PlayerId)
                .IsRequired();

            base.Configure(builder);
        }
    }
}
