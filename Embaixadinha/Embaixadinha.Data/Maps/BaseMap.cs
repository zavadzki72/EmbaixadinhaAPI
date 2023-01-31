using Embaixadinha.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Embaixadinha.Data.Maps
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public BaseMap(string tableName)
        {
            TableName = tableName;
        }

        public string TableName { get; }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.ToTable(TableName);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(x => x.Created_At)
                .IsRequired();

            builder.Property(x => x.Updated_At)
                .IsRequired();
        }
    }
}
