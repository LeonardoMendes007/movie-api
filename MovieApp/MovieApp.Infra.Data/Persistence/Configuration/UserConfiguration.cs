using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Domain.Entities;

namespace MovieApp.Infra.Data.Persistence.Configuration;
public class ApplicationUserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("tb_user");
        builder.Property(x => x.Id).HasColumnName("id").HasMaxLength(36);
        builder.Property(x => x.CreatedDate).HasColumnName("CreateDate").IsRequired();
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdateDate");

        builder.HasKey(x => x.Id);

        builder.HasMany(e => e.MoviesRating)
        .WithMany(e => e.UserRating)
        .UsingEntity<Rating>();

        builder.HasMany(e => e.FavoritesMovies)
            .WithMany(e => e.FavoritesUsers)
            .UsingEntity("tb_favorites_movies");
    }
}
