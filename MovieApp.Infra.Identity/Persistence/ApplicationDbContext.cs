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
        builder.Entity<User>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(u => u.ApplicationId)
            .IsRequired();

        base.OnModelCreating(builder);
    }
}
