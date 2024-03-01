using Microsoft.AspNetCore.Identity;

namespace MovieApp.Domain.Entities;
public class ApplicationUser : IdentityUser
{
    public Guid UserId { get; set; }
    public User User { get; set; }
}
