using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using MovieApp.Infra.Identity.Identity;

namespace MovieApp.Infra.Identity.Persistence;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>()
            .Property(x => x.UserName).IsRequired();
        builder.Entity<ApplicationUser>()
            .Property(x => x.Email).IsRequired();

        builder.Entity<ApplicationUser>()
            .HasIndex(x => x.UserName);
        builder.Entity<ApplicationUser>()
            .HasIndex(x => x.Email);

        base.OnModelCreating(builder);
    }
}
