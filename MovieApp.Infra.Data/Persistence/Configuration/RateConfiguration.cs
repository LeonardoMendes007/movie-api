using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class RateConfiguration : IEntityTypeConfiguration<Rate>
{
    public void Configure(EntityTypeBuilder<Rate> builder)
    {
        builder.ToTable("tb_rate");
        builder.Property(x => x.Comment).HasColumnName("comment").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Grade).HasColumnName("views");
        builder.Property(x => x.CreatedDate).HasColumnName("dt_create").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("dt_update");

    }
}
