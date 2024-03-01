using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("tb_user");
        builder.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        builder.Property(x => x.UserName).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("dt_create").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("dt_update");

        builder.HasIndex(x => x.UserName).IsUnique();

        builder.HasMany(e => e.MovieRatings)
        .WithMany(e => e.UserRatings)
        .UsingEntity<Rating>();

        builder.HasMany(e => e.FavoritesMovies)
            .WithMany(e => e.FavoritesUsers)
            .UsingEntity("tb_favorites_movies");
    }
}
