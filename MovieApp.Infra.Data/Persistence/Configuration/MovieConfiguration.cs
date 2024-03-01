using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain.Entities;
using System.Reflection.Emit;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("tb_movie");
        builder.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Synopsis).HasColumnName("synopsis").HasMaxLength(500).IsRequired();
        builder.Property(x => x.Views).HasColumnName("views").HasDefaultValue(0);
        builder.Property(x => x.ReleaseDate).HasColumnName("dt_release").IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("dt_create").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("dt_update");

        builder.HasIndex(x => new { x.Name, x.ReleaseDate}).IsUnique();

        builder.HasMany(e => e.UserRatings)
        .WithMany(e => e.MovieRatings)
        .UsingEntity<Rating>();

        builder.HasMany(e => e.Genries)
           .WithMany(e => e.Movies)
           .UsingEntity("tb_genre_movie");

        


    }
}
