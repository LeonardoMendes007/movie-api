using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MovieApp.Domain.Dtos;
using MovieApp.Domain.Interfaces.Repository;
using MovieApp.Infra.Identity.Identity;

namespace MovieApp.Infra.Identity.Persistence.Repositories;
public class AuthRepository : IAuthRepository
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AuthRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<bool> RegisterAsync(CreateUserDto createUserDto, string password)
    {
        var appUser = new ApplicationUser() {
            UserName = createUserDto.UserName,
            Email = createUserDto.Email
        };

        var identityResult = await _userManager.CreateAsync(appUser, password);

        return identityResult.Succeeded;
    }

    public async Task<bool> SignInAsync(string userName, string password)
    {
        var userAuth = await _userManager.FindByNameAsync(userName);
        return userAuth != null && await _userManager.CheckPasswordAsync(userAuth, password);
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Rollback()
    {
        await _context.DisposeAsync();
    }


}