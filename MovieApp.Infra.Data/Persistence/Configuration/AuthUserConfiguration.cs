using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.CreatedDate).HasColumnName("CreateDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdateDate");

        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();

        builder.HasMany(e => e.MoviesRating)
        .WithMany(e => e.UserRating)
        .UsingEntity<Rating>();

        builder.HasMany(e => e.FavoritesMovies)
            .WithMany(e => e.FavoritesUsers)
            .UsingEntity("tb_favorites_movies");
    }
}
