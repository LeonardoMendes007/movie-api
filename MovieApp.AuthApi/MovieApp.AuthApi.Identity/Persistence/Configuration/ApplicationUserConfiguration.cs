using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.AuthApi.Identity.Identity;

namespace MovieApp.AuthApi.Identity.Persistence.Configuration;
internal class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(x => x.UserName).IsRequired();
        builder.Property(x => x.Email).IsRequired();

        builder.HasIndex(x => x.UserName);
        builder.HasIndex(x => x.Email);
    }
}
