using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class RatingConfiguration : IEntityTypeConfiguration<Rating>
{
    public void Configure(EntityTypeBuilder<Rating> builder)
    {
        builder.ToTable("tb_rating");
        builder.Property(x => x.Comment).HasColumnName("comment").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Score).HasColumnName("score").HasMaxLength(1).IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("dt_create").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("dt_update");

        builder.HasKey(x => new {x.UserId, x.MovieId});


    }
}
