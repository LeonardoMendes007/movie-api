using AutoMapper;
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

    public async Task<ApplicationUser> RegisterAsync(ApplicationUser appUser, string password)
    {
        var identityResult = await _userManager.CreateAsync(appUser);
        
        if (identityResult.Succeeded)
        {
            return await _userManager.FindByNameAsync(appUser.UserName);
        }

        return null;
    }

    public async Task<ApplicationUser> SignInAsync(string userName, string password)
    {
        var userAuth = await _userManager.FindByNameAsync(userName);
        return (userAuth != null && await _userManager.CheckPasswordAsync(userAuth, password)) ? userAuth : null;
    }

    public async Task<IdentityResult> UpdateAsync(ApplicationUser appUser)
    {
        return await _userManager.UpdateAsync(appUser);
    }

    public async Task<IdentityResult> ChangePassword(ApplicationUser appUser, string currentPassword, string newPassword)
    {
        return await _userManager.ChangePasswordAsync(appUser, currentPassword, newPassword);
    }

}