
using Microsoft.AspNetCore.Identity;
using MovieApp.Domain.Entities;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Identity.Identity;
using MovieApp.Infra.Identity.Interfaces.Services;
using MovieApp.Infra.Identity.Model;

namespace MovieApp.Infra.Identity.Services;
public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserRepository _userRepository;

    public AuthService(UserManager<ApplicationUser> userManager, IUserRepository userRepository)
    {
        _userManager = userManager;
        _userRepository = userRepository;
    }

    public async  Task<AuthResult> RegisterAccount(string userName, string email, string password)
    {
        var appUser = new ApplicationUser()
        {
            UserName = userName,
            Email = email
        };

        var identityResult = await _userManager.CreateAsync(appUser, password);

        if (!identityResult.Succeeded)
            return new AuthResult(false);

        var userDomain = new User(Guid.Parse(appUser.Id), userName, email);

        await _userRepository.SaveAsync(userDomain);
        await _userRepository.CommitAsync();

        var credential = new Credential { id = appUser.Id, UserName = appUser.UserName, Email = appUser.Email };

        return new AuthResult(credential, true);
    }

    public async Task<AuthResult> SignInAsync(string email, string password)
    {
        var appUser = await _userManager.FindByEmailAsync(email);
        if (appUser != null && await _userManager.CheckPasswordAsync(appUser, password))
        {
            var credential = new Credential { id = appUser.Id, UserName = appUser.UserName, Email = appUser.Email };

            return new AuthResult(credential, true);
        }

        return new AuthResult(false);
    }
}
