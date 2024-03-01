using Microsoft.AspNetCore.Identity;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repository;

namespace MovieApp.Infra.Data.Persistence.Repositories;
public class AuthRepository : IAuthRepository
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AuthRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterAsync(ApplicationUser authUser, string password)
    {
        return await _userManager.CreateAsync(authUser, password);
    }

    public async Task<bool> LoginAsync(string userName, string password)
    {
        var userAuth = await _userManager.FindByNameAsync(userName);
        return (userAuth != null && await _userManager.CheckPasswordAsync(userAuth, password));
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser authUser)
    {
        return await _userManager.UpdateAsync(authUser);
    }

    public async Task<IdentityResult> ChangePassword(ApplicationUser authUser, string currentPassword, string newPassword)
    {
        return await _userManager.ChangePasswordAsync(authUser, currentPassword, newPassword);
    }

}