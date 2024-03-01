using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Infra.Data.Persistence;
public sealed class MovieAppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<ApplicationUser> Users { get; set; } = default!;

    public DbSet<Movie> Movies { get; set; } = default!;

    public DbSet<Rating> Ratings { get; set; } = default!;

    public DbSet<Genre> Genres { get; set; } = default!;

    public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
    : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(MovieAppDbContext)
            .Assembly);
    }
}
